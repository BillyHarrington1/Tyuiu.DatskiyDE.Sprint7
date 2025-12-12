namespace AppVideoClips
{
    partial class FormWatchVideo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            buttonImport = new Button();
            buttonRefresh = new Button();
            buttonYouTube = new Button();
            labelTitle = new Label();
            buttonClose = new Button();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            flowPanelVideos = new FlowLayoutPanel();
            panelControls = new Panel();
            buttonPlay = new Button();
            buttonPause = new Button();
            trackVolume = new TrackBar();
            labelVolume = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackVolume).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(40, 40, 40);
            panelTop.Controls.Add(buttonImport);
            panelTop.Controls.Add(buttonRefresh);
            panelTop.Controls.Add(buttonYouTube);
            panelTop.Controls.Add(labelTitle);
            panelTop.Controls.Add(buttonClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 48);
            panelTop.TabIndex = 0;
            panelTop.MouseDown += panelTop_MouseDown;
            panelTop.MouseMove += panelTop_MouseMove;
            // 
            // buttonImport
            // 
            buttonImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonImport.AutoSize = true;
            buttonImport.BackColor = Color.FromArgb(40, 40, 40);
            buttonImport.FlatStyle = FlatStyle.Popup;
            buttonImport.ForeColor = Color.WhiteSmoke;
            buttonImport.Location = new Point(820, 12);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(80, 25);
            buttonImport.TabIndex = 4;
            buttonImport.Text = "Добавить";
            buttonImport.UseVisualStyleBackColor = false;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefresh.AutoSize = true;
            buttonRefresh.BackColor = Color.FromArgb(40, 40, 40);
            buttonRefresh.FlatStyle = FlatStyle.Popup;
            buttonRefresh.ForeColor = Color.WhiteSmoke;
            buttonRefresh.Location = new Point(900, 12);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(80, 25);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonYouTube
            // 
            buttonYouTube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonYouTube.AutoSize = true;
            buttonYouTube.BackColor = Color.FromArgb(40, 40, 40);
            buttonYouTube.FlatStyle = FlatStyle.Popup;
            buttonYouTube.ForeColor = Color.WhiteSmoke;
            buttonYouTube.Location = new Point(1020, 12);
            buttonYouTube.Name = "buttonYouTube";
            buttonYouTube.Size = new Size(80, 25);
            buttonYouTube.TabIndex = 2;
            buttonYouTube.Text = "YouTube";
            buttonYouTube.UseVisualStyleBackColor = false;
            buttonYouTube.Click += buttonYouTube_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.Location = new Point(12, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(96, 13);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Просмотр видео";
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClose.AutoSize = true;
            buttonClose.BackColor = Color.FromArgb(40, 40, 40);
            buttonClose.FlatStyle = FlatStyle.Popup;
            buttonClose.ForeColor = Color.WhiteSmoke;
            buttonClose.Location = new Point(1106, 10);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(80, 27);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.Black;
            webView2.Dock = DockStyle.Fill;
            webView2.Location = new Point(0, 48);
            webView2.Name = "webView2";
            webView2.Size = new Size(840, 624);
            webView2.TabIndex = 2;
            webView2.ZoomFactor = 2D;
            // 
            // flowPanelVideos
            // 
            flowPanelVideos.AutoScroll = true;
            flowPanelVideos.BackColor = Color.FromArgb(30, 30, 30);
            flowPanelVideos.Dock = DockStyle.Right;
            flowPanelVideos.Location = new Point(840, 48);
            flowPanelVideos.Name = "flowPanelVideos";
            flowPanelVideos.Size = new Size(360, 624);
            flowPanelVideos.TabIndex = 3;
            // 
            // panelControls
            // 
            panelControls.BackColor = Color.FromArgb(20, 20, 20);
            panelControls.Controls.Add(buttonPlay);
            panelControls.Controls.Add(buttonPause);
            panelControls.Controls.Add(trackVolume);
            panelControls.Controls.Add(labelVolume);
            panelControls.Dock = DockStyle.Bottom;
            panelControls.Location = new Point(0, 672);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(1200, 48);
            panelControls.TabIndex = 4;
            // 
            // buttonPlay
            // 
            buttonPlay.AutoSize = true;
            buttonPlay.Location = new Point(8, 10);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(75, 25);
            buttonPlay.TabIndex = 0;
            buttonPlay.Text = "Play";
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonPause
            // 
            buttonPause.AutoSize = true;
            buttonPause.Location = new Point(80, 10);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new Size(75, 25);
            buttonPause.TabIndex = 1;
            buttonPause.Text = "Pause";
            buttonPause.Click += buttonPause_Click;
            // 
            // trackVolume
            // 
            trackVolume.Location = new Point(160, 8);
            trackVolume.Maximum = 100;
            trackVolume.Name = "trackVolume";
            trackVolume.Size = new Size(150, 45);
            trackVolume.TabIndex = 2;
            trackVolume.Value = 100;
            trackVolume.Scroll += trackVolume_Scroll;
            // 
            // labelVolume
            // 
            labelVolume.AutoSize = true;
            labelVolume.ForeColor = Color.WhiteSmoke;
            labelVolume.Location = new Point(320, 12);
            labelVolume.Name = "labelVolume";
            labelVolume.Size = new Size(45, 13);
            labelVolume.TabIndex = 3;
            labelVolume.Text = "Volume";
            // 
            // FormWatchVideo
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1200, 720);
            Controls.Add(webView2);
            Controls.Add(flowPanelVideos);
            Controls.Add(panelControls);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWatchVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр видео";
            WindowState = FormWindowState.Maximized;
            Load += FormWatchVideo_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackVolume).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonYouTube;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonClose;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private System.Windows.Forms.FlowLayoutPanel flowPanelVideos;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label labelVolume;
    }
}