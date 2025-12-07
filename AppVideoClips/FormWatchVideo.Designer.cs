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
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonYouTube = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.flowPanelVideos = new System.Windows.Forms.FlowLayoutPanel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panelTop.Controls.Add(this.buttonImport);
            this.panelTop.Controls.Add(this.buttonRefresh);
            this.panelTop.Controls.Add(this.buttonYouTube);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 48);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImport.AutoSize = true;
            this.buttonImport.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonImport.Location = new System.Drawing.Point(820, 12);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(80, 24);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "Добавить";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.AutoSize = true;
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRefresh.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRefresh.Location = new System.Drawing.Point(900, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(80, 24);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonYouTube
            // 
            this.buttonYouTube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonYouTube.AutoSize = true;
            this.buttonYouTube.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.buttonYouTube.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonYouTube.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonYouTube.Location = new System.Drawing.Point(1020, 12);
            this.buttonYouTube.Name = "buttonYouTube";
            this.buttonYouTube.Size = new System.Drawing.Size(80, 24);
            this.buttonYouTube.TabIndex = 2;
            this.buttonYouTube.Text = "YouTube";
            this.buttonYouTube.UseVisualStyleBackColor = false;
            this.buttonYouTube.Click += new System.EventHandler(this.buttonYouTube_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(12, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(91, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Просмотр видео";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.AutoSize = true;
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.Location = new System.Drawing.Point(1106, 10);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 27);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // webView2
            // 
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.Black;
            this.webView2.Location = new System.Drawing.Point(0, 48);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(840, 572);
            this.webView2.TabIndex = 2;
            this.webView2.ZoomFactor = 1D;
            // 
            // flowPanelVideos
            // 
            this.flowPanelVideos.AutoScroll = true;
            this.flowPanelVideos.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.flowPanelVideos.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPanelVideos.Location = new System.Drawing.Point(840, 48);
            this.flowPanelVideos.Name = "flowPanelVideos";
            this.flowPanelVideos.Size = new System.Drawing.Size(360, 612);
            this.flowPanelVideos.TabIndex = 3;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Height = 48;
            this.panelControls.Name = "panelControls";
            this.panelControls.TabIndex = 4;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Text = "Play";
            this.buttonPlay.AutoSize = true;
            this.buttonPlay.Location = new System.Drawing.Point(8, 10);
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Text = "Pause";
            this.buttonPause.AutoSize = true;
            this.buttonPause.Location = new System.Drawing.Point(80, 10);
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // trackVolume
            // 
            this.trackVolume.Location = new System.Drawing.Point(160, 8);
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Size = new System.Drawing.Size(150, 45);
            this.trackVolume.Minimum = 0;
            this.trackVolume.Maximum = 100;
            this.trackVolume.Value = 100;
            this.trackVolume.Scroll += new System.EventHandler(this.trackVolume_Scroll);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelVolume.Location = new System.Drawing.Point(320, 12);
            this.labelVolume.Text = "Volume";
            // 
            // add controls to panelControls
            // 
            this.panelControls.Controls.Add(this.buttonPlay);
            this.panelControls.Controls.Add(this.buttonPause);
            this.panelControls.Controls.Add(this.trackVolume);
            this.panelControls.Controls.Add(this.labelVolume);
            // 
            // FormWatchVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.webView2);
            this.Controls.Add(this.flowPanelVideos);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWatchVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр видео";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormWatchVideo_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            this.ResumeLayout(false);

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