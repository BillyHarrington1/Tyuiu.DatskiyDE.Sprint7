namespace AppVideoClips
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            // ensure this welcome form stays above other windows
            this.TopMost = true;

            Theme.ApplyTheme(this);

            try
            {
                var btn = new Button { Text = "Тема", Size = new Size(70, 28), BackColor = Color.Transparent, FlatStyle = FlatStyle.Flat, ForeColor = Theme.Foreground };
                btn.Click += (s, e) => Theme.ToggleTheme(this);
                btn.Location = new Point(this.ClientSize.Width - 90, 8);
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                Controls.Add(btn);
                btn.BringToFront();
            }
            catch { }
        }

        private void buttonGo_GAM_Click(object sender, EventArgs e)
        {
            // Signal to Program that user wants to open main workspace
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void buttonManagement_GAM_Click(object sender, EventArgs e)
        {
            FormManual formmanual = new FormManual();
            formmanual.TopMost = true;
            formmanual.ShowDialog();
        }

        private void buttonAbout_GAM_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.TopMost = true;
            formAbout.ShowDialog();
        }

        private void buttonExit_GAM_Click(object sender, EventArgs e)
        {
            // Signal to Program to exit
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void labelName_GAM_Click(object sender, EventArgs e)
        {

        }

        // Open the dedicated FormWatchVideo window instead of simple placeholder
        private void buttonWatch_GAM_Click(object sender, EventArgs e)
        {
            using (var watch = new FormWatchVideo())
            {
                watch.TopMost = true;
                // Hide the menu while watching
                this.Hide();
                watch.ShowDialog();
                this.Show();
            }
        }
    }
}
