namespace AppVideoClips
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            this.TopMost = true;

            Theme.ApplyTheme(this);

            try
            {
                var existing = Controls.OfType<Button>().FirstOrDefault(b => b.Name == "buttonTheme_Added");
                if (existing == null)
                {
                    var btn = new Button { Name = "buttonTheme_Added", Text = "Тема", Size = new Size(70, 28), BackColor = Color.Transparent, FlatStyle = FlatStyle.Flat, ForeColor = Theme.Foreground };
                    btn.Click += (s, e) => Theme.ToggleThemeGlobal();
                    btn.Location = new Point(this.ClientSize.Width - 90, 8);
                    btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    Controls.Add(btn);
                    btn.BringToFront();
                }
            }
            catch { }
        }

        private void buttonGo_GAM_Click(object sender, EventArgs e)
        {
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void labelName_GAM_Click(object sender, EventArgs e)
        {

        }
        private void buttonWatch_GAM_Click(object sender, EventArgs e)
        {
            using (var watch = new FormWatchVideo())
            {
                watch.TopMost = true;         
                this.Hide();
                watch.ShowDialog();
                this.Show();
            }
        }
    }
}
