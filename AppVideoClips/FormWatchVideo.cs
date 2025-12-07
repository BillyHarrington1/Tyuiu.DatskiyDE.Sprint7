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

namespace AppVideoClips
{
    public partial class FormWatchVideo : Form
    {
        private bool dragging = false;
        private Point dragStart;

        public FormWatchVideo()
        {
            InitializeComponent();
        }

        private async void FormWatchVideo_Load(object sender, EventArgs e)
        {
            // initialize WebView2
            try
            {
                await webView2.EnsureCoreWebView2Async();
            }
            catch { }

            // populate 6 tiles from Resources/Videos folder (project relative)
            string videosDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Videos");
            if (!Directory.Exists(videosDir)) Directory.CreateDirectory(videosDir);

            var files = Directory.GetFiles(videosDir).Where(f => IsVideoFile(f)).Take(6).ToArray();

            for (int i = 0; i < 6; i++)
            {
                var panel = CreateVideoTile(i < files.Length ? files[i] : null, i + 1);
                flowPanelVideos.Controls.Add(panel);
            }
        }

        private bool IsVideoFile(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext == ".mp4" || ext == ".webm" || ext == ".avi" || ext == ".mov";
        }

        private Panel CreateVideoTile(string filePath, int index)
        {
            var p = new Panel();
            p.Width = flowPanelVideos.ClientSize.Width - 20;
            p.Height = 100;
            p.Margin = new Padding(8);
            p.BackColor = Color.FromArgb(40, 40, 40);

            var thumb = new PictureBox();
            thumb.Width = 160;
            thumb.Height = 90;
            thumb.Location = new Point(8, 5);
            thumb.SizeMode = PictureBoxSizeMode.Zoom;
            thumb.BackColor = Color.Black;

            var label = new Label();
            label.ForeColor = Color.WhiteSmoke;
            label.Location = new Point(176, 8);
            label.AutoSize = false;
            label.Size = new Size(p.Width - 184, 60);
            label.Text = filePath != null ? Path.GetFileName(filePath) : "(no video)";

            var btn = new Button();
            btn.Text = "Play";
            btn.Location = new Point(176, 68);
            btn.Size = new Size(80, 24);
            btn.Tag = filePath;
            btn.Click += Btn_Click;

            p.Controls.Add(thumb);
            p.Controls.Add(label);
            p.Controls.Add(btn);

            return p;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (sender is Button b)
            {
                var file = b.Tag as string;
                if (!string.IsNullOrWhiteSpace(file) && File.Exists(file))
                {
                    // play local file using file:// URL in WebView2
                    var url = new Uri(file).AbsoluteUri;
                    webView2.CoreWebView2.Navigate(url);
                }
                else
                {
                    MessageBox.Show("Локальный файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
            // open youtube frontpage in webview; user can paste URL there
            try
            {
                webView2.CoreWebView2.Navigate("https://www.youtube.com");
            }
            catch
            {
            }
        }
    }
}
