using System.Windows.Forms;

namespace AppVideoClips
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
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
    }
}
