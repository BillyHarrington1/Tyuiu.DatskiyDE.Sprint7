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
                var btn = new Button { Text = "Тема", Size = new Size(70, 28), BackColor = Color.Transparent, FlatStyle = FlatStyle.Flat, ForeColor = Theme.Foreground };
                btn.Click += (s, e) => Theme.ToggleTheme(this);
                btn.Location = new Point(this.ClientSize.Width - 90, 8);
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                Controls.Add(btn);
                btn.BringToFront();
            }
            catch { }
        }
    }
}
