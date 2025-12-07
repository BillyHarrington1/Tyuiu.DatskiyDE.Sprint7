namespace AppVideoClips
{
    partial class FormAbout
    {
        PictureBox pictureBox_DDE;
        Label labelText_DDE;

        private void InitializeComponent()
        {
            pictureBox_DDE = new PictureBox();
            labelText_DDE = new Label();

            pictureBox_DDE.Dock = System.Windows.Forms.DockStyle.Top;
            pictureBox_DDE.Height = 200;
            pictureBox_DDE.SizeMode = PictureBoxSizeMode.Zoom;

            labelText_DDE.Dock = System.Windows.Forms.DockStyle.Fill;
            labelText_DDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelText_DDE.Text = "Каталог видеоклипов\nРазработчик: DDE\n2025";

            Controls.Add(labelText_DDE);
            Controls.Add(pictureBox_DDE);

            Text = "О программе";
            Width = 400;
            Height = 400;
        }
    }
}
