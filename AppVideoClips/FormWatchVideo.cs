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

namespace AppVideoClips
{
    public partial class FormWatchVideo : Form
    {
        private bool dragging = false;
        private Point dragStart;
        private List<string> videoFiles = new List<string>();
        private int page = 0;
        private int pageSize = 6;

        public FormWatchVideo()
        {
            InitializeComponent();
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
            var btnPrev = new Button { Text = "<< Prev", Enabled = page > 0, Width = 80, Location = new Point(8, 6) };
            var btnNext = new Button { Text = "Next >>", Enabled = (page + 1) * pageSize < videoFiles.Count, Width = 80, Location = new Point(96, 6) };
            btnPrev.Click += (s, e) => { page = Math.Max(0, page - 1); RenderPage(); };
            btnNext.Click += (s, e) => { if ((page + 1) * pageSize < videoFiles.Count) { page++; RenderPage(); } };
            navPanel.Controls.Add(btnPrev); navPanel.Controls.Add(btnNext);
            flowPanelVideos.Controls.Add(navPanel);
        }

        private Panel CreateVideoTileLarge(string filePath)
        {
            var p = new Panel();
            p.Width = flowPanelVideos.ClientSize.Width - 20;
            p.Height = 180;
            p.Margin = new Padding(8);
            p.BackColor = Color.FromArgb(40, 40, 40);

            var thumb = new PictureBox();
            thumb.Width = 320;
            thumb.Height = 180;
            thumb.Location = new Point(0, 0);
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
            label.ForeColor = Color.WhiteSmoke;
            label.Location = new Point(328, 8);
            label.AutoSize = false;
            label.Size = new Size(p.Width - 336, 100);
            label.Text = filePath != null ? Path.GetFileName(filePath) : "(no video)";

            var info = new Label();
            info.ForeColor = Color.LightGray;
            info.Location = new Point(328, 112);
            info.AutoSize = false;
            info.Size = new Size(p.Width - 336, 48);
            info.Text = filePath != null ? GetVideoInfo(filePath) : string.Empty;

            // Make the whole panel clickable: attach click handlers to panel and all child controls
            p.Cursor = Cursors.Hand;
            p.Tag = filePath;
            p.Click += Tile_Click;
            thumb.Click += Tile_Click;
            label.Click += Tile_Click;
            info.Click += Tile_Click;

            p.Controls.Add(thumb);
            p.Controls.Add(label);
            p.Controls.Add(info);

            return p;
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

                Task.Run(() =>
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
            LoadVideoFiles();
            RenderPage();
        }
    }
}
