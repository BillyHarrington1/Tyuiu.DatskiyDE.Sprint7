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
            panelTop_DDE = new Panel();
            buttonImport_DDE = new Button();
            buttonRefresh_DDE = new Button();
            buttonYouTube_DDE = new Button();
            buttonRutube_DDE = new Button();
            buttonVK_DDE = new Button();
            buttonTwitch_DDE = new Button();
            labelTitle_DDE = new Label();
            buttonMinimize_DDE = new Button();
            buttonClose_DDE = new Button();
            buttonToggleSidebar_DDE = new Button();
            webView_DDE = new Microsoft.Web.WebView2.WinForms.WebView2();
            flowPanelVideos_DDE = new FlowLayoutPanel();
            panelSidebar = new Panel();
            panelControls_DDE = new Panel();
            buttonPlay_DDE = new Button();
            buttonPause_DDE = new Button();
            buttonSubtitle_DDE = new Button();
            buttonSettings_DDE = new Button();
            buttonEdit_DDE = new Button();
            trackVolume_DDE = new TrackBar();
            labelVolume = new Label();
            panelTop_DDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView_DDE).BeginInit();
            panelSidebar.SuspendLayout();
            panelControls_DDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackVolume_DDE).BeginInit();
            SuspendLayout();
            // 
            // panelTop_DDE
            // 
            panelTop_DDE.BackColor = Color.FromArgb(40, 40, 40);
            panelTop_DDE.Controls.Add(buttonImport_DDE);
            panelTop_DDE.Controls.Add(buttonRefresh_DDE);
            panelTop_DDE.Controls.Add(buttonYouTube_DDE);
            panelTop_DDE.Controls.Add(buttonRutube_DDE);
            panelTop_DDE.Controls.Add(buttonVK_DDE);
            panelTop_DDE.Controls.Add(buttonTwitch_DDE);
            panelTop_DDE.Controls.Add(labelTitle_DDE);
            panelTop_DDE.Controls.Add(buttonMinimize_DDE);
            panelTop_DDE.Controls.Add(buttonClose_DDE);
            panelTop_DDE.Controls.Add(buttonToggleSidebar_DDE);
            panelTop_DDE.Dock = DockStyle.Top;
            panelTop_DDE.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            panelTop_DDE.Location = new Point(0, 0);
            panelTop_DDE.Name = "panelTop_DDE";
            panelTop_DDE.Size = new Size(1200, 48);
            panelTop_DDE.TabIndex = 0;
            panelTop_DDE.MouseDown += panelTop_MouseDown;
            panelTop_DDE.MouseMove += panelTop_MouseMove;
            // 
            // buttonImport_DDE
            // 
            buttonImport_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonImport_DDE.AutoSize = true;
            buttonImport_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonImport_DDE.FlatStyle = FlatStyle.Popup;
            buttonImport_DDE.ForeColor = Color.WhiteSmoke;
            buttonImport_DDE.Location = new Point(830, 3);
            buttonImport_DDE.Name = "buttonImport_DDE";
            buttonImport_DDE.Size = new Size(89, 45);
            buttonImport_DDE.TabIndex = 4;
            buttonImport_DDE.Text = "Добавить";
            buttonImport_DDE.UseVisualStyleBackColor = false;
            buttonImport_DDE.Click += buttonImport_Click;
            // 
            // buttonRefresh_DDE
            // 
            buttonRefresh_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefresh_DDE.AutoSize = true;
            buttonRefresh_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonRefresh_DDE.FlatStyle = FlatStyle.Popup;
            buttonRefresh_DDE.ForeColor = Color.WhiteSmoke;
            buttonRefresh_DDE.Location = new Point(925, 3);
            buttonRefresh_DDE.Name = "buttonRefresh_DDE";
            buttonRefresh_DDE.Size = new Size(94, 45);
            buttonRefresh_DDE.TabIndex = 5;
            buttonRefresh_DDE.Text = "Обновить ";
            buttonRefresh_DDE.UseVisualStyleBackColor = false;
            buttonRefresh_DDE.Click += buttonRefresh_Click;
            // 
            // buttonYouTube_DDE
            // 
            buttonYouTube_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonYouTube_DDE.AutoSize = true;
            buttonYouTube_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonYouTube_DDE.FlatStyle = FlatStyle.Popup;
            buttonYouTube_DDE.ForeColor = Color.WhiteSmoke;
            buttonYouTube_DDE.Location = new Point(624, 3);
            buttonYouTube_DDE.Name = "buttonYouTube_DDE";
            buttonYouTube_DDE.Size = new Size(80, 44);
            buttonYouTube_DDE.TabIndex = 2;
            buttonYouTube_DDE.Text = "YouTube";
            buttonYouTube_DDE.UseVisualStyleBackColor = false;
            buttonYouTube_DDE.Click += buttonYouTube_Click;
            // 
            // buttonRutube_DDE
            // 
            buttonRutube_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRutube_DDE.AutoSize = true;
            buttonRutube_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonRutube_DDE.FlatStyle = FlatStyle.Popup;
            buttonRutube_DDE.ForeColor = Color.WhiteSmoke;
            buttonRutube_DDE.Location = new Point(710, 3);
            buttonRutube_DDE.Name = "buttonRutube_DDE";
            buttonRutube_DDE.Size = new Size(75, 44);
            buttonRutube_DDE.TabIndex = 6;
            buttonRutube_DDE.Text = "Рутуб";
            buttonRutube_DDE.UseVisualStyleBackColor = false;
            buttonRutube_DDE.Click += buttonRutube_Click;
            // 
            // buttonVK_DDE
            // 
            buttonVK_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonVK_DDE.AutoSize = true;
            buttonVK_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonVK_DDE.FlatStyle = FlatStyle.Popup;
            buttonVK_DDE.ForeColor = Color.WhiteSmoke;
            buttonVK_DDE.Location = new Point(537, 2);
            buttonVK_DDE.Name = "buttonVK_DDE";
            buttonVK_DDE.Size = new Size(81, 44);
            buttonVK_DDE.TabIndex = 7;
            buttonVK_DDE.Text = "ВКВидео";
            buttonVK_DDE.UseVisualStyleBackColor = false;
            buttonVK_DDE.Click += buttonVK_Click;
            // 
            // buttonTwitch_DDE
            // 
            buttonTwitch_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTwitch_DDE.AutoSize = true;
            buttonTwitch_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonTwitch_DDE.FlatStyle = FlatStyle.Popup;
            buttonTwitch_DDE.ForeColor = Color.WhiteSmoke;
            buttonTwitch_DDE.Location = new Point(456, 3);
            buttonTwitch_DDE.Name = "buttonTwitch_DDE";
            buttonTwitch_DDE.Size = new Size(78, 44);
            buttonTwitch_DDE.TabIndex = 8;
            buttonTwitch_DDE.Text = "Twitch";
            buttonTwitch_DDE.UseVisualStyleBackColor = false;
            buttonTwitch_DDE.Click += buttonTwitch_Click;
            // 
            // labelTitle_DDE
            // 
            labelTitle_DDE.AutoSize = true;
            labelTitle_DDE.ForeColor = Color.WhiteSmoke;
            labelTitle_DDE.Location = new Point(12, 15);
            labelTitle_DDE.Name = "labelTitle_DDE";
            labelTitle_DDE.Size = new Size(122, 23);
            labelTitle_DDE.TabIndex = 1;
            labelTitle_DDE.Text = "Просмотр видео";
            // 
            // buttonMinimize_DDE
            // 
            buttonMinimize_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMinimize_DDE.AutoSize = true;
            buttonMinimize_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonMinimize_DDE.FlatStyle = FlatStyle.Popup;
            buttonMinimize_DDE.Font = new Font("Segoe UI", 18F);
            buttonMinimize_DDE.ForeColor = Color.WhiteSmoke;
            buttonMinimize_DDE.Location = new Point(1086, 2);
            buttonMinimize_DDE.Name = "buttonMinimize_DDE";
            buttonMinimize_DDE.Size = new Size(53, 45);
            buttonMinimize_DDE.TabIndex = 9;
            buttonMinimize_DDE.Text = "_";
            buttonMinimize_DDE.UseVisualStyleBackColor = false;
            buttonMinimize_DDE.Click += buttonMinimize_Click;
            // 
            // buttonClose_DDE
            // 
            buttonClose_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClose_DDE.AutoSize = true;
            buttonClose_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonClose_DDE.FlatStyle = FlatStyle.Popup;
            buttonClose_DDE.Font = new Font("Segoe UI", 18F);
            buttonClose_DDE.ForeColor = Color.White;
            buttonClose_DDE.Location = new Point(1145, 3);
            buttonClose_DDE.Name = "buttonClose_DDE";
            buttonClose_DDE.Size = new Size(52, 45);
            buttonClose_DDE.TabIndex = 0;
            buttonClose_DDE.Text = "X";
            buttonClose_DDE.UseVisualStyleBackColor = false;
            buttonClose_DDE.Click += buttonClose_Click;
            // 
            // buttonToggleSidebar_DDE
            // 
            buttonToggleSidebar_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToggleSidebar_DDE.AutoSize = true;
            buttonToggleSidebar_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonToggleSidebar_DDE.FlatStyle = FlatStyle.Popup;
            buttonToggleSidebar_DDE.ForeColor = Color.WhiteSmoke;
            buttonToggleSidebar_DDE.Location = new Point(1025, 2);
            buttonToggleSidebar_DDE.Name = "buttonToggleSidebar_DDE";
            buttonToggleSidebar_DDE.Size = new Size(55, 46);
            buttonToggleSidebar_DDE.TabIndex = 10;
            buttonToggleSidebar_DDE.Text = "≡";
            buttonToggleSidebar_DDE.UseVisualStyleBackColor = false;
            buttonToggleSidebar_DDE.Click += buttonToggleSidebar_Click;
            // 
            // webView_DDE
            // 
            webView_DDE.AllowExternalDrop = true;
            webView_DDE.CreationProperties = null;
            webView_DDE.DefaultBackgroundColor = Color.Black;
            webView_DDE.Dock = DockStyle.Fill;
            webView_DDE.Location = new Point(0, 48);
            webView_DDE.Name = "webView_DDE";
            webView_DDE.Size = new Size(840, 624);
            webView_DDE.TabIndex = 2;
            webView_DDE.ZoomFactor = 1D;
            // 
            // flowPanelVideos_DDE
            // 
            flowPanelVideos_DDE.AutoScroll = true;
            flowPanelVideos_DDE.BackColor = Color.FromArgb(30, 30, 30);
            flowPanelVideos_DDE.Dock = DockStyle.Fill;
            flowPanelVideos_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            flowPanelVideos_DDE.Location = new Point(0, 0);
            flowPanelVideos_DDE.Name = "flowPanelVideos_DDE";
            flowPanelVideos_DDE.Size = new Size(360, 624);
            flowPanelVideos_DDE.TabIndex = 3;
            flowPanelVideos_DDE.Paint += flowPanelVideos_Paint;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(30, 30, 30);
            panelSidebar.Controls.Add(flowPanelVideos_DDE);
            panelSidebar.Dock = DockStyle.Right;
            panelSidebar.Location = new Point(840, 48);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(360, 624);
            panelSidebar.TabIndex = 3;
            // 
            // panelControls_DDE
            // 
            panelControls_DDE.BackColor = Color.FromArgb(20, 20, 20);
            panelControls_DDE.Controls.Add(buttonPlay_DDE);
            panelControls_DDE.Controls.Add(buttonPause_DDE);
            panelControls_DDE.Controls.Add(buttonSubtitle_DDE);
            panelControls_DDE.Controls.Add(buttonSettings_DDE);
            panelControls_DDE.Controls.Add(buttonEdit_DDE);
            panelControls_DDE.Controls.Add(trackVolume_DDE);
            panelControls_DDE.Controls.Add(labelVolume);
            panelControls_DDE.Dock = DockStyle.Bottom;
            panelControls_DDE.Location = new Point(0, 672);
            panelControls_DDE.Name = "panelControls_DDE";
            panelControls_DDE.Size = new Size(1200, 48);
            panelControls_DDE.TabIndex = 4;
            // 
            // buttonPlay_DDE
            // 
            buttonPlay_DDE.AutoSize = true;
            buttonPlay_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            buttonPlay_DDE.ForeColor = SystemColors.Control;
            buttonPlay_DDE.Location = new Point(8, 10);
            buttonPlay_DDE.Name = "buttonPlay_DDE";
            buttonPlay_DDE.Size = new Size(75, 31);
            buttonPlay_DDE.TabIndex = 0;
            buttonPlay_DDE.Text = "Пуск";
            buttonPlay_DDE.Click += buttonPlay_Click;
            // 
            // buttonPause_DDE
            // 
            buttonPause_DDE.AutoSize = true;
            buttonPause_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            buttonPause_DDE.ForeColor = SystemColors.Control;
            buttonPause_DDE.Location = new Point(90, 10);
            buttonPause_DDE.Name = "buttonPause_DDE";
            buttonPause_DDE.Size = new Size(75, 31);
            buttonPause_DDE.TabIndex = 1;
            buttonPause_DDE.Text = "Пауза";
            buttonPause_DDE.Click += buttonPause_Click;
            // 
            // buttonSubtitle_DDE
            // 
            buttonSubtitle_DDE.AutoSize = true;
            buttonSubtitle_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            buttonSubtitle_DDE.ForeColor = SystemColors.Control;
            buttonSubtitle_DDE.Location = new Point(186, 10);
            buttonSubtitle_DDE.Name = "buttonSubtitle_DDE";
            buttonSubtitle_DDE.Size = new Size(90, 31);
            buttonSubtitle_DDE.TabIndex = 4;
            buttonSubtitle_DDE.Text = "Субтитры";
            buttonSubtitle_DDE.UseVisualStyleBackColor = true;
            buttonSubtitle_DDE.Click += buttonSubtitle_Click;
            // 
            // buttonSettings_DDE
            // 
            buttonSettings_DDE.AutoSize = true;
            buttonSettings_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            buttonSettings_DDE.ForeColor = SystemColors.Control;
            buttonSettings_DDE.Location = new Point(303, 10);
            buttonSettings_DDE.Name = "buttonSettings_DDE";
            buttonSettings_DDE.Size = new Size(95, 31);
            buttonSettings_DDE.TabIndex = 5;
            buttonSettings_DDE.Text = "Настройки";
            buttonSettings_DDE.UseVisualStyleBackColor = true;
            buttonSettings_DDE.Click += buttonSettings_Click;
            // 
            // buttonEdit_DDE
            // 
            buttonEdit_DDE.AutoSize = true;
            buttonEdit_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            buttonEdit_DDE.ForeColor = SystemColors.Control;
            buttonEdit_DDE.Location = new Point(404, 10);
            buttonEdit_DDE.Name = "buttonEdit_DDE";
            buttonEdit_DDE.Size = new Size(95, 31);
            buttonEdit_DDE.TabIndex = 6;
            buttonEdit_DDE.Text = "Редактор";
            buttonEdit_DDE.UseVisualStyleBackColor = true;
            buttonEdit_DDE.Click += buttonEdit_Click;
            // 
            // trackVolume_DDE
            // 
            trackVolume_DDE.Location = new Point(496, 6);
            trackVolume_DDE.Maximum = 100;
            trackVolume_DDE.Name = "trackVolume_DDE";
            trackVolume_DDE.Size = new Size(335, 45);
            trackVolume_DDE.TabIndex = 2;
            trackVolume_DDE.Value = 100;
            trackVolume_DDE.Scroll += trackVolume_Scroll;
            // 
            // labelVolume
            // 
            labelVolume.AutoSize = true;
            labelVolume.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            labelVolume.ForeColor = Color.WhiteSmoke;
            labelVolume.Location = new Point(830, 15);
            labelVolume.Name = "labelVolume";
            labelVolume.Size = new Size(38, 21);
            labelVolume.TabIndex = 3;
            labelVolume.Text = "Звук";
            // 
            // FormWatchVideo
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1200, 720);
            Controls.Add(webView_DDE);
            Controls.Add(panelSidebar);
            Controls.Add(panelControls_DDE);
            Controls.Add(panelTop_DDE);
            Font = new Font("Segoe UI", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWatchVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр видео";
            WindowState = FormWindowState.Maximized;
            Load += FormWatchVideo_Load;
            panelTop_DDE.ResumeLayout(false);
            panelTop_DDE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView_DDE).EndInit();
            panelSidebar.ResumeLayout(false);
            panelControls_DDE.ResumeLayout(false);
            panelControls_DDE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackVolume_DDE).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop_DDE;
        private System.Windows.Forms.Button buttonImport_DDE;
        private System.Windows.Forms.Button buttonRefresh_DDE;
        private System.Windows.Forms.Button buttonYouTube_DDE;
        private System.Windows.Forms.Button buttonRutube_DDE;
        private System.Windows.Forms.Button buttonVK_DDE;
        private System.Windows.Forms.Button buttonTwitch_DDE;
        private System.Windows.Forms.Label labelTitle_DDE;
        private System.Windows.Forms.Button buttonClose_DDE;
        private System.Windows.Forms.Button buttonMinimize_DDE;
        private System.Windows.Forms.Button buttonToggleSidebar_DDE;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView_DDE;
        private System.Windows.Forms.FlowLayoutPanel flowPanelVideos_DDE;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelControls_DDE;
        private System.Windows.Forms.Button buttonPlay_DDE;
        private System.Windows.Forms.Button buttonPause_DDE;
        private System.Windows.Forms.Button buttonSubtitle_DDE;
        private System.Windows.Forms.Button buttonSettings_DDE;
        private System.Windows.Forms.Button buttonEdit_DDE;
        private System.Windows.Forms.TrackBar trackVolume_DDE;
        private System.Windows.Forms.Label labelVolume;
    }
}