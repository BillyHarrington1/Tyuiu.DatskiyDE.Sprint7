namespace AppVideoClips
{
    partial class FormAbout
    {
        PictureBox pictureBox_DDE;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            pictureBox_DDE = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_DDE).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_DDE
            // 
            pictureBox_DDE.Dock = DockStyle.Top;
            pictureBox_DDE.Image = (Image)resources.GetObject("pictureBox_DDE.Image");
            pictureBox_DDE.Location = new Point(0, 0);
            pictureBox_DDE.Name = "pictureBox_DDE";
            pictureBox_DDE.Size = new Size(384, 259);
            pictureBox_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_DDE.TabIndex = 1;
            pictureBox_DDE.TabStop = false;
            // 
            // FormAbout
            // 
            ClientSize = new Size(384, 258);
            Controls.Add(pictureBox_DDE);
            Name = "FormAbout";
            Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)pictureBox_DDE).EndInit();
            ResumeLayout(false);
        }
    }
}
