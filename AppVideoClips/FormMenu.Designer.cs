namespace AppVideoClips
{
    partial class FormMenu
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
            labelName_DDE = new Label();
            buttonGo_DDE = new Button();
            buttonManagement_DDE = new Button();
            buttonAbout_DDE = new Button();
            buttonExit_DDE = new Button();
            pictureBoxIco_DDE = new PictureBox();
            buttonWatch_DDE = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIco_DDE).BeginInit();
            SuspendLayout();
            // 
            // labelName_DDE
            // 
            labelName_DDE.AutoSize = true;
            labelName_DDE.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelName_DDE.ForeColor = Color.WhiteSmoke;
            labelName_DDE.Location = new Point(358, 35);
            labelName_DDE.Margin = new Padding(4, 0, 4, 0);
            labelName_DDE.Name = "labelName_DDE";
            labelName_DDE.Size = new Size(511, 65);
            labelName_DDE.TabIndex = 0;
            labelName_DDE.Text = "Каталог видео клипов";
            labelName_DDE.Click += labelName_GAM_Click;
            // 
            // buttonGo_DDE
            // 
            buttonGo_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonGo_DDE.FlatStyle = FlatStyle.Popup;
            buttonGo_DDE.Font = new Font("Segoe UI", 12F);
            buttonGo_DDE.ForeColor = Color.WhiteSmoke;
            buttonGo_DDE.Location = new Point(368, 173);
            buttonGo_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonGo_DDE.Name = "buttonGo_DDE";
            buttonGo_DDE.Size = new Size(294, 78);
            buttonGo_DDE.TabIndex = 1;
            buttonGo_DDE.Text = "Перейти в рабочую среду\r\n";
            buttonGo_DDE.UseVisualStyleBackColor = false;
            buttonGo_DDE.Click += buttonGo_GAM_Click;
            // 
            // buttonManagement_DDE
            // 
            buttonManagement_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonManagement_DDE.FlatStyle = FlatStyle.Popup;
            buttonManagement_DDE.Font = new Font("Segoe UI", 12F);
            buttonManagement_DDE.ForeColor = Color.WhiteSmoke;
            buttonManagement_DDE.Location = new Point(14, 449);
            buttonManagement_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonManagement_DDE.Name = "buttonManagement_DDE";
            buttonManagement_DDE.Size = new Size(130, 69);
            buttonManagement_DDE.TabIndex = 1;
            buttonManagement_DDE.Text = "Руководство";
            buttonManagement_DDE.UseVisualStyleBackColor = false;
            buttonManagement_DDE.Click += buttonManagement_GAM_Click;
            // 
            // buttonAbout_DDE
            // 
            buttonAbout_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonAbout_DDE.FlatStyle = FlatStyle.Popup;
            buttonAbout_DDE.Font = new Font("Segoe UI", 12F);
            buttonAbout_DDE.ForeColor = Color.WhiteSmoke;
            buttonAbout_DDE.Location = new Point(150, 449);
            buttonAbout_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonAbout_DDE.Name = "buttonAbout_DDE";
            buttonAbout_DDE.Size = new Size(130, 69);
            buttonAbout_DDE.TabIndex = 1;
            buttonAbout_DDE.Text = "О программе";
            buttonAbout_DDE.UseVisualStyleBackColor = false;
            buttonAbout_DDE.Click += buttonAbout_GAM_Click;
            // 
            // buttonWatch_DDE
            // 
            buttonWatch_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonWatch_DDE.FlatStyle = FlatStyle.Popup;
            buttonWatch_DDE.Font = new Font("Segoe UI", 12F);
            buttonWatch_DDE.ForeColor = Color.WhiteSmoke;
            buttonWatch_DDE.Location = new Point(368, 260);
            buttonWatch_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonWatch_DDE.Name = "buttonWatch_DDE";
            buttonWatch_DDE.Size = new Size(294, 60);
            buttonWatch_DDE.TabIndex = 2;
            buttonWatch_DDE.Text = "Перейти в просмотр видео";
            buttonWatch_DDE.UseVisualStyleBackColor = false;
            buttonWatch_DDE.Click += buttonWatch_GAM_Click;
            // 
            // buttonExit_DDE
            // 
            buttonExit_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonExit_DDE.FlatStyle = FlatStyle.Popup;
            buttonExit_DDE.Font = new Font("Segoe UI", 12F);
            buttonExit_DDE.ForeColor = Color.WhiteSmoke;
            buttonExit_DDE.Location = new Point(826, 479);
            buttonExit_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonExit_DDE.Name = "buttonExit_DDE";
            buttonExit_DDE.Size = new Size(98, 39);
            buttonExit_DDE.TabIndex = 1;
            buttonExit_DDE.Text = "Выход";
            buttonExit_DDE.UseVisualStyleBackColor = false;
            buttonExit_DDE.Click += buttonExit_GAM_Click;
            // 
            // pictureBoxIco_DDE
            // 
            pictureBoxIco_DDE.Location = new Point(1, 10);
            pictureBoxIco_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxIco_DDE.Name = "pictureBoxIco_DDE";
            pictureBoxIco_DDE.Size = new Size(359, 411);
            pictureBoxIco_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIco_DDE.TabIndex = 2;
            pictureBoxIco_DDE.TabStop = false;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(938, 532);
            Controls.Add(pictureBoxIco_DDE);
            Controls.Add(buttonExit_DDE);
            Controls.Add(buttonAbout_DDE);
            Controls.Add(buttonManagement_DDE);
            Controls.Add(buttonWatch_DDE);
            Controls.Add(buttonGo_DDE);
            Controls.Add(labelName_DDE);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CSV Maestro";
            ((System.ComponentModel.ISupportInitialize)pictureBoxIco_DDE).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName_DDE;
        private System.Windows.Forms.Button buttonGo_DDE;
        private System.Windows.Forms.Button buttonManagement_DDE;
        private System.Windows.Forms.Button buttonAbout_DDE;
        private System.Windows.Forms.Button buttonExit_DDE;
        private System.Windows.Forms.PictureBox pictureBoxIco_DDE;
        private System.Windows.Forms.Button buttonWatch_DDE;
    }
}