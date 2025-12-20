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

        public FormWatchVideo()
        {
            InitializeComponent();

            favStorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AppVideoClips", "favorites.json");
            LoadFavorites();

            // Only run runtime UI adjustments when not in designer
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                // Apply theme globally
                Theme.ApplyTheme(this);

                panelTop.BackColor = Theme.Panel;
                panelControls.BackColor = Theme.PanelAlt;
                panelSidebar.BackColor = Theme.Panel;
                flowPanelVideos.BackColor = Theme.PanelAlt;

                // style new buttons
                foreach (var b in new[] { buttonYouTube, buttonRutube, buttonVK, buttonTwitch })
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Theme.IconColor;
                }

                // Only attach handlers here that are not wired by designer
                // (designer already wires Click handlers in InitializeComponent)
                buttonMinimize.Click += MinimizeButton_Click;

                // ensure webview resizes when sidebar toggled
                this.Resize += (s, e) => LayoutPanels();
            }
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
            // toggle visibility once (designer click handler calls this)
            sidebarVisible = !sidebarVisible;
            panelSidebar.Visible = sidebarVisible;
            panelSidebar.Width = sidebarVisible ? 360 : 0;
            // update layout
            LayoutPanels();
        }

        private void LayoutPanels()
        {
            // refresh controls so dock/size settle
            panelSidebar.Refresh();
            webView2.Refresh();
            this.PerformLayout();
            this.Refresh();
        }

        private void NavigateTo(string url)
        {
            try
            {
                if (webView2.CoreWebView2 == null) _ = webView2.EnsureCoreWebView2Async();
                webView2.CoreWebView2.Navigate(url);
            }
            catch { }
        }

        private async void FormWatchVideo_Load(object sender, EventArgs e)
        {
            try
            {
                await webView2.EnsureCoreWebView2Async();
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
            flowPanelVideos.Controls.Clear();

            var pageItems = videoFiles.Skip(page * pageSize).Take(pageSize).ToList();

            foreach (var f in pageItems)
            {
                var tile = CreateVideoTileLarge(f);
                flowPanelVideos.Controls.Add(tile);
            }

            // if fewer than pageSize, fill empty tiles
            for (int i = pageItems.Count; i < pageSize; i++)
            {
                var tile = CreateVideoTileLarge(null);
                flowPanelVideos.Controls.Add(tile);
            }

            // add pagination controls at bottom
            var navPanel = new Panel { Width = flowPanelVideos.ClientSize.Width - 20, Height = 40, BackColor = Color.Transparent };
            var btnPrev = new Button { Text = "<< Назад", Enabled = page > 0, Width = 80, Location = new Point(8, 6) };
            var btnNext = new Button { Text = "Вперед >>", Enabled = (page + 1) * pageSize < videoFiles.Count, Width = 80, Location = new Point(96, 6) };
            btnPrev.Click += (s, e) => { page = Math.Max(0, page - 1); RenderPage(); };
            btnNext.Click += (s, e) => { if ((page + 1) * pageSize < videoFiles.Count) { page++; RenderPage(); } };
            navPanel.Controls.Add(btnPrev); navPanel.Controls.Add(btnNext);
            flowPanelVideos.Controls.Add(navPanel);
        }

        private Panel CreateVideoTileLarge(string filePath)
        {
            var p = new Panel();
            p.Width = flowPanelVideos.ClientSize.Width - 20;
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
                    // fallback: no thumbnail
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

            // Make the whole panel clickable: attach click handlers to panel and all child controls
            p.Cursor = Cursors.Hand;
            p.Tag = filePath;
            p.Click += Tile_Click;
            thumb.Click += Tile_Click;
            label.Click += Tile_Click;
            info.Click += Tile_Click;

            // Add controls
            p.Controls.Add(thumb);
            p.Controls.Add(label);
            p.Controls.Add(info);
            p.Controls.Add(progress);
            p.Controls.Add(fav);

            // Apply theme for the tile
            Theme.ApplyTheme(p);

            return p;
        }

        private void UpdateTileProgress(string file, int value)
        {
            try
            {
                foreach (Control c in flowPanelVideos.Controls)
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

        private async Task PlayLocalFileAsync(string file)
        {
            try
            {
                if (webView2.CoreWebView2 == null)
                {
                    await webView2.EnsureCoreWebView2Async();
                }

                var folder = Path.GetDirectoryName(file) ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Videos");
                try
                {
                    // Use reflection to avoid ambiguous enum type between assemblies
                    var core = webView2.CoreWebView2;
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

                var html = $@"<!doctype html>
                <html>
                <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=Edge' />
                <style>body{{margin:0;background:black;display:flex;align-items:center;justify-content:center;height:100vh}}video{{max-width:100%;max-height:100%}}</style>
                </head>
                <body>
                <video id='v' controls autoplay>
                <source src='{Uri.EscapeDataString(fileName)}' type='{mime}'>
                Your browser does not support the video tag.
                </video>
                <script>
                const v = document.getElementById('v');
                window.chrome.webview.addEventListener('message', e => {{
                 const data = e.data;
                 const cmd = data.cmd;
                 const value = data.value;
                 if (cmd === 'play') v.play();
                 if (cmd === 'pause') v.pause();
                 if (cmd === 'volume') v.volume = value;
                }});
                </script>
                </body>
                </html>";

                File.WriteAllText(playerPath, html, Encoding.UTF8);

                var hostUrl = $"https://appassets/{Uri.EscapeUriString(playerName)}";

                // Navigate to the generated player
                webView2.CoreWebView2.Navigate(hostUrl);

                // Mark as watched (set progress to 100) for demo purposes
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

        private string GetVideoInfo(string path)
        {
            try
            {
                var fi = new FileInfo(path);
                return $"Size: {fi.Length / 1024 / 1024} MB";
            }
            catch { return string.Empty; }
        }

        private bool IsVideoFile(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext == ".mp4" || ext == ".webm" || ext == ".avi" || ext == ".mov";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging = false;
        }

        private void buttonYouTube_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView2.CoreWebView2 == null)
                {
                    _ = webView2.EnsureCoreWebView2Async();
                }
                webView2.CoreWebView2.Navigate("https://www.youtube.com");
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
                if (webView2.CoreWebView2 != null)
                    webView2.CoreWebView2.PostWebMessageAsJson("{\"cmd\":\"play\"}");
            }
            catch { }
        }

        private async void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView2.CoreWebView2 != null)
                    webView2.CoreWebView2.PostWebMessageAsJson("{\"cmd\":\"pause\"}");
            }
            catch { }
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            var v = trackVolume.Value / 100.0;
            try
            {
                if (webView2.CoreWebView2 != null)
                    webView2.CoreWebView2.PostWebMessageAsJson($"{{\"cmd\":\"volume\",\"value\":{v.ToString(System.Globalization.CultureInfo.InvariantCulture)} }}");
            }
            catch { }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadVideoFiles();
            RenderPage();
        }

        // Import button support
        private void ImportVideo(string sourcePath)
        {
            if (!File.Exists(sourcePath)) return;
            string videosDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Videos");
            if (!Directory.Exists(videosDir)) Directory.CreateDirectory(videosDir);
            string dest = Path.Combine(videosDir, Path.GetFileName(sourcePath));
            File.Copy(sourcePath, dest, true);

            // generate a simple placeholder subtitles file in SRT format (auto-subtitles stub)
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
    }
}
