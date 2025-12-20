using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Web.WebView2.Core;
using Microsoft.WindowsAPICodePack.Shell;
using System.Text;
using System.Reflection;
using System.Text.Json;
using System.Diagnostics;

namespace AppVideoClips
{
    public partial class FormWatchVideo : Form
    {
        private bool dragging = false;
        private Point dragStart;
        private List<string> videoFiles = new List<string>();
        private int page = 0;
        private int pageSize = 6;
        private bool sidebarVisible = true;

        private HashSet<string> favorites = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, int> progressMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private string favStorePath;

        private bool subtitlesEnabled = false;

        public FormWatchVideo()
        {
            InitializeComponent();
       
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;

            favStorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AppVideoClips", "favorites.json");
            LoadFavorites();
       
            Theme.ApplyTheme(this);

            panelTop_DDE.BackColor = Theme.Panel;
            panelControls_DDE.BackColor = Theme.PanelAlt;
            panelSidebar.BackColor = Theme.Panel;
            flowPanelVideos_DDE.BackColor = Theme.PanelAlt;

          
            foreach (var b in new[] { buttonYouTube_DDE, buttonRutube_DDE, buttonVK_DDE, buttonTwitch_DDE })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = Color.Transparent;
                b.ForeColor = Theme.IconColor;
            }
            buttonMinimize_DDE.Click += MinimizeButton_Click;

           
            this.Resize += (s, e) => LayoutPanels();
        }

        private void LoadFavorites()
        {
            try
            {
                var dir = Path.GetDirectoryName(favStorePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                if (File.Exists(favStorePath))
                {
                    var json = File.ReadAllText(favStorePath, Encoding.UTF8);
                    var list = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                    favorites = new HashSet<string>(list, StringComparer.OrdinalIgnoreCase);
                }
            }
            catch { }
        }

        private void SaveFavorites()
        {
            try
            {
                var dir = Path.GetDirectoryName(favStorePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var list = favorites.ToList();
                var json = JsonSerializer.Serialize(list);
                File.WriteAllText(favStorePath, json, Encoding.UTF8);
            }
            catch { }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ToggleSidebar()
        {
          
            sidebarVisible = !sidebarVisible;
            panelSidebar.Visible = sidebarVisible;
            panelSidebar.Width = sidebarVisible ? 360 : 0;
            LayoutPanels();
        }

        private void LayoutPanels()
        {
          
            panelSidebar.Refresh();
            webView_DDE.Refresh();
            this.PerformLayout();
            this.Refresh();
        }

        private void NavigateTo(string url)
        {
            try
            {
                if (webView_DDE.CoreWebView2 == null) _ = webView_DDE.EnsureCoreWebView2Async();
                webView_DDE.CoreWebView2.Navigate(url);
            }
            catch { }
        }

        private async void FormWatchVideo_Load(object sender, EventArgs e)
        {
            try
            {
                await webView_DDE.EnsureCoreWebView2Async();
            }
            catch { }

            LoadVideoFiles();
            RenderPage();
        }

        private void LoadVideoFiles()
        {
            string videosDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Videos");
            if (!Directory.Exists(videosDir)) Directory.CreateDirectory(videosDir);

            videoFiles = Directory.GetFiles(videosDir)
                .Where(f => IsVideoFile(f))
                .OrderBy(f => f)
                .ToList();
        }

        private void RenderPage()
        {
            flowPanelVideos_DDE.Controls.Clear();

            var pageItems = videoFiles.Skip(page * pageSize).Take(pageSize).ToList();

            foreach (var f in pageItems)
            {
                var tile = CreateVideoTileLarge(f);
                flowPanelVideos_DDE.Controls.Add(tile);
            }

        
            for (int i = pageItems.Count; i < pageSize; i++)
            {
                var tile = CreateVideoTileLarge(null);
                flowPanelVideos_DDE.Controls.Add(tile);
            }

         
            var navPanel = new Panel { Width = flowPanelVideos_DDE.ClientSize.Width - 20, Height = 40, BackColor = Color.Transparent };
            var btnPrev = new Button { Text = "<< Назад", Enabled = page > 0, Width = 80, Location = new Point(8, 6) };
            var btnNext = new Button { Text = "Вперед >>", Enabled = (page + 1) * pageSize < videoFiles.Count, Width = 80, Location = new Point(96, 6) };
            btnPrev.Click += (s, e) => { page = Math.Max(0, page - 1); RenderPage(); };
            btnNext.Click += (s, e) => { if ((page + 1) * pageSize < videoFiles.Count) { page++; RenderPage(); } };
            navPanel.Controls.Add(btnPrev); navPanel.Controls.Add(btnNext);
            flowPanelVideos_DDE.Controls.Add(navPanel);
        }

        private Panel CreateVideoTileLarge(string filePath)
        {
            var p = new Panel();
            p.Width = flowPanelVideos_DDE.ClientSize.Width - 20;
            p.Height = 220;
            p.Margin = new Padding(8);
            p.BackColor = Theme.PanelAlt;

            var thumb = new PictureBox();
            thumb.Width = 320;
            thumb.Height = 180;
            thumb.Location = new Point(8, 8);
            thumb.SizeMode = PictureBoxSizeMode.Zoom;
            thumb.BackColor = Color.Black;

            if (filePath != null && File.Exists(filePath))
            {
                try
                {
                    using var shell = ShellFile.FromFilePath(filePath);
                    var bmp = shell.Thumbnail.LargeBitmap;
                    thumb.Image = new Bitmap(bmp);
                }
                catch
                {
                   
                }
            }

            var label = new Label();
            label.ForeColor = Theme.Foreground;
            label.Location = new Point(336, 8);
            label.AutoSize = false;
            label.Size = new Size(p.Width - 344, 48);
            label.Text = filePath != null ? Path.GetFileName(filePath) : "(no video)";

            var info = new Label();
            info.ForeColor = Theme.Foreground;
            info.Location = new Point(336, 56);
            info.AutoSize = false;
            info.Size = new Size(p.Width - 344, 40);
            info.Text = filePath != null ? GetVideoInfo(filePath) : string.Empty;

            var progress = new ProgressBar();
            progress.Style = ProgressBarStyle.Continuous;
            progress.Location = new Point(336, 96);
            progress.Size = new Size(p.Width - 360, 20);
            progress.Value = progressMap.TryGetValue(filePath ?? string.Empty, out var v) ? Math.Min(100, v) : 0;

            var fav = new Button();
            fav.Text = favorites.Contains(filePath ?? string.Empty) ? "♥" : "♡";
            fav.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fav.BackColor = Color.Transparent;
            fav.FlatStyle = FlatStyle.Flat;
            fav.FlatAppearance.BorderSize = 0;
            fav.ForeColor = favorites.Contains(filePath ?? string.Empty) ? Color.Gold : Theme.Foreground;
            fav.Location = new Point(p.Width - 48, 8);
            fav.Size = new Size(36, 36);
            fav.Cursor = Cursors.Hand;
            fav.Click += (s, e) =>
            {
                if (filePath == null) return;
                if (favorites.Contains(filePath)) { favorites.Remove(filePath); fav.Text = "♡"; fav.ForeColor = Theme.Foreground; }
                else { favorites.Add(filePath); fav.Text = "♥"; fav.ForeColor = Color.Gold; }
                SaveFavorites();
            };

          
            p.Cursor = Cursors.Hand;
            p.Tag = filePath;
            p.Click += Tile_Click;
            thumb.Click += Tile_Click;
            label.Click += Tile_Click;
            info.Click += Tile_Click;

       
            p.Controls.Add(thumb);
            p.Controls.Add(label);
            p.Controls.Add(info);
            p.Controls.Add(progress);
            p.Controls.Add(fav);
            Theme.ApplyTheme(p);

            return p;
        }

        private void UpdateTileProgress(string file, int value)
        {
            try
            {
                foreach (Control c in flowPanelVideos_DDE.Controls)
                {
                    if (c is Panel p && (p.Tag as string) == file)
                    {
                        var prog = p.Controls.OfType<ProgressBar>().FirstOrDefault();
                        if (prog != null)
                        {
                            prog.Value = Math.Min(100, Math.Max(0, value));
                        }
                        break;
                    }
                }
            }
            catch { }
        }

        private void Tile_Click(object? sender, EventArgs e)
        {
            string? file = null;
            if (sender is Control ctrl)
            {
                Panel? par = null;
                if (ctrl is Panel p) par = p;
                else if (ctrl.Parent is Panel parentPanel) par = parentPanel;
                if (par != null) file = par.Tag as string;
            }

            if (!string.IsNullOrWhiteSpace(file) && File.Exists(file))
            {
                _ = PlayLocalFileAsync(file);
            }
        }

        private void buttonSubtitle_Click(object sender, EventArgs e)
        {
      
            subtitlesEnabled = !subtitlesEnabled;
            buttonSubtitle_DDE.Text = subtitlesEnabled ? "Субтитры: Вкл" : "Субтитры";
        
            try
            {
                if (webView_DDE.CoreWebView2 != null && webView_DDE.CoreWebView2.Source != null)
                {
                    var cmd = JsonSerializer.Serialize(new { cmd = "captions", value = subtitlesEnabled });
                    webView_DDE.CoreWebView2.PostWebMessageAsJson(cmd);
                }
            }
            catch { }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            using var settings = new Form();
            settings.Text = "Настройки плеера";
            settings.ClientSize = new Size(400, 300);
            settings.StartPosition = FormStartPosition.CenterParent;
            settings.FormBorderStyle = FormBorderStyle.FixedDialog;
            settings.TopMost = true;

            var lbl = new Label { Text = "Настройки автосубтитров и воспроизведения", Dock = DockStyle.Top, Height = 40 };
            settings.Controls.Add(lbl);

            var cb = new ComboBox { Dock = DockStyle.Top, Height = 30 };
            cb.Items.AddRange(new string[] { "ru", "en" });
            cb.SelectedIndex = 0;
            settings.Controls.Add(cb);

            var btnGen = new Button { Text = "Генерировать автосубтитры (локально)", Dock = DockStyle.Top, Height = 30 };
            btnGen.Click += (s, e2) =>
            {
                using var ofd = new OpenFileDialog();
                ofd.Filter = "Video files|*.mp4;*.webm;*.avi;*.mov|All files|*.*";
                if (ofd.ShowDialog(settings) == DialogResult.OK)
                {
                    GenerateAutoSubtitlesLocal(ofd.FileName);
                    MessageBox.Show(settings, "Генерация отправлена (если установлен движок).", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            settings.Controls.Add(btnGen);

            var btnThemeLocal = new Button { Text = "Сменить тему (везде)", Dock = DockStyle.Top, Height = 30 };
            btnThemeLocal.Click += (s, e2) => Theme.ToggleThemeGlobal();
            settings.Controls.Add(btnThemeLocal);

            var btnOk = new Button { Text = "OK", Dock = DockStyle.Bottom, Height = 30 };
            btnOk.Click += (s, e2) => settings.Close();
            settings.Controls.Add(btnOk);

            Theme.ApplyTheme(settings);
            settings.ShowDialog(this);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
       
            using var editForm = new FormVideoEditor();
            editForm.StartPosition = FormStartPosition.CenterParent;
            editForm.TopMost = true;
            editForm.ShowDialog(this);
        }

        private void GenerateAutoSubtitlesLocal(string file)
        {
            try
            {
              
                var dir = Path.GetDirectoryName(file);
                var fileName = Path.GetFileName(file);

             
                var whisperCmd = "whisper";
                var args = $"\"{file}\" --model tiny --task transcribe --output_format srt --output_dir \"{dir}\"";

                var psi = new ProcessStartInfo(whisperCmd, args)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                var p = Process.Start(psi);
                if (p != null)
                {
                    p.WaitForExit();
                }
                else
                {
                    MessageBox.Show(this, "Не удалось запустить whisper. Установите python-openai-whisper или whisper.cpp и добавьте в PATH.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ошибка генерации автосубтитров: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonYouTube_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView_DDE.CoreWebView2 == null)
                {
                    _ = webView_DDE.EnsureCoreWebView2Async();
                }
                webView_DDE.CoreWebView2.Navigate("https://www.youtube.com");
            }
            catch { }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Video files|*.mp4;*.webm;*.avi;*.mov|All files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImportVideo(ofd.FileName);
            }
        }

        private async void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView_DDE.CoreWebView2 != null)
                    webView_DDE.CoreWebView2.PostWebMessageAsJson("{\"cmd\":\"play\"}");
            }
            catch { }
        }

        private async void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView_DDE.CoreWebView2 != null)
                    webView_DDE.CoreWebView2.PostWebMessageAsJson("{\"cmd\":\"pause\"}");
            }
            catch { }
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            var v = trackVolume_DDE.Value / 100.0;
            try
            {
                if (webView_DDE.CoreWebView2 != null)
                    webView_DDE.CoreWebView2.PostWebMessageAsJson($"{{\"cmd\":\"volume\",\"value\":{v.ToString(System.Globalization.CultureInfo.InvariantCulture)} }}");
            }
            catch { }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadVideoFiles();
            RenderPage();
        }

     
        private void ImportVideo(string sourcePath)
        {
            if (!File.Exists(sourcePath)) return;
            string videosDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Videos");
            if (!Directory.Exists(videosDir)) Directory.CreateDirectory(videosDir);
            string dest = Path.Combine(videosDir, Path.GetFileName(sourcePath));
            File.Copy(sourcePath, dest, true);

          
            try
            {
                var srtPath = Path.ChangeExtension(dest, ".srt");
                if (!File.Exists(srtPath))
                {
                    var lines = new List<string>
                    {
                        "1\r\n00:00:00,000 --> 00:00:05,000\r\n[Автосубтитры не доступны]",
                        ""
                    };
                    File.WriteAllText(srtPath, string.Join("\r\n", lines), Encoding.UTF8);
                }
            }
            catch { }

            LoadVideoFiles();
            RenderPage();
        }

        private void buttonRutube_Click(object sender, EventArgs e)
        {
            NavigateTo("https://rutube.ru");
        }

        private void buttonVK_Click(object sender, EventArgs e)
        {
            NavigateTo("https://vk.com/video");
        }

        private void buttonTwitch_Click(object sender, EventArgs e)
        {
            NavigateTo("https://www.twitch.tv");
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonToggleSidebar_Click(object sender, EventArgs e)
        {
            ToggleSidebar();
        }

        private void flowPanelVideos_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragStart = new Point(e.X, e.Y);
            }
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var p = PointToScreen(e.Location);
                this.Location = new Point(p.X - dragStart.X, p.Y - dragStart.Y);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsVideoFile(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext == ".mp4" || ext == ".webm" || ext == ".avi" || ext == ".mov";
        }

        private string GetVideoInfo(string path)
        {
            try
            {
                var fi = new FileInfo(path);
                return $"Size: {fi.Length / 1024 / 1024} MB";
            }
            catch { return string.Empty; }
        }

        private async Task PlayLocalFileAsync(string file)
        {
            try
            {
                if (webView_DDE.CoreWebView2 == null)
                {
                    await webView_DDE.EnsureCoreWebView2Async();
                }

                var folder = Path.GetDirectoryName(file) ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Videos");
                try
                {
                    var core = webView_DDE.CoreWebView2;
                    var coreType = core.GetType();
                    var enumType = Type.GetType("Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind, Microsoft.Web.WebView2.Core");
                    if (enumType != null)
                    {
                        var allowVal = Enum.Parse(enumType, "Allow");
                        var method = coreType.GetMethod("SetVirtualHostNameToFolderMapping", BindingFlags.Instance | BindingFlags.Public);
                        if (method != null)
                        {
                            method.Invoke(core, new object[] { "appassets", folder, allowVal });
                        }
                    }
                }
                catch { }
              
                if (Path.GetExtension(file).Equals(".mp4", StringComparison.OrdinalIgnoreCase))
                {
                    EnsureProceduralSubtitles(file);
                }

                var fileName = Path.GetFileName(file);

                var playerName = $"player_{Guid.NewGuid():N}.html";
                var playerPath = Path.Combine(folder, playerName);

                var ext = Path.GetExtension(file).ToLowerInvariant();
                var mime = ext switch
                {
                    ".mp4" => "video/mp4",
                    ".webm" => "video/webm",
                    ".ogg" => "video/ogg",
                    _ => "video/mp4",
                };

                var srtName = Path.ChangeExtension(file, ".srt");
                var track = "";
                if (File.Exists(srtName))
                {
                    track = $"<track id='subs' label='Subtitles' kind='subtitles' src='{Uri.EscapeDataString(Path.GetFileName(srtName))}' default>";
                }

                var html = $@"<!doctype html>
                <html>
                <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=Edge' />
                <style>body{{margin:0;background:black;display:flex;align-items:center;justify-content:center;height:100vh}}video{{max-width:100%;max-height:100%}}::cue{{background:rgba(0,0,0,0.6);color:white}}</style>
                </head>
                <body>
                <video id='v' controls autoplay>
                <source src='{Uri.EscapeDataString(fileName)}' type='{mime}'>
                {track}
                Your browser does not support the video tag.
                </video>
                <script>
                const v = document.getElementById('v');
                function setCaptions(enabled){{
                  try{{
                  var t = v.textTracks[0];
                  if (t) t.mode = enabled ? 'showing' : 'hidden';
                  }}catch(e){{}}
                }}
                window.chrome.webview.addEventListener('message', e => {{
                  const data = e.data;
                  const cmd = data.cmd;
                  const value = data.value;
                  if (cmd === 'play') v.play();
                  if (cmd === 'pause') v.pause();
                  if (cmd === 'volume') v.volume = value;
                  if (cmd === 'captions') setCaptions(value);
                }});
                setCaptions(false);
                </script>
                </body>
                </html>";

                File.WriteAllText(playerPath, html, Encoding.UTF8);

                var hostUrl = $"https://appassets/{Uri.EscapeUriString(playerName)}";

                webView_DDE.CoreWebView2.Navigate(hostUrl);

                progressMap[file] = 100;
                UpdateTileProgress(file, 100);

             
                _ = Task.Run(() =>
                {
                    try
                    {
                        var files = Directory.GetFiles(folder, "player_*.html");
                        foreach (var f in files)
                        {
                            try
                            {
                                if (File.GetCreationTimeUtc(f) < DateTime.UtcNow.AddDays(-1)) File.Delete(f);
                            }
                            catch { }
                        }
                    }
                    catch { }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось воспроизвести файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Процедурная генерация субтитров 
        private void EnsureProceduralSubtitles(string file)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(file) || !File.Exists(file)) return;
                var srt = Path.ChangeExtension(file, ".srt");
                if (File.Exists(srt)) return;

                var sb = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    int start = i * 5;
                    int end = start + 5;
                    sb.AppendLine((i + 1).ToString());
                    sb.AppendLine(TimeSpan.FromSeconds(start).ToString(@"hh\:mm\:ss") + ",000 --> " + TimeSpan.FromSeconds(end).ToString(@"hh\:mm\:ss") + ",000");
                    sb.AppendLine("Auto-caption line " + (i + 1));
                    sb.AppendLine();
                }
                File.WriteAllText(srt, sb.ToString(), Encoding.UTF8);
            }
            catch { }
        }
    }
}
