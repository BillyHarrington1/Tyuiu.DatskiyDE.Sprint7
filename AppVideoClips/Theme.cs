using System.Drawing;
using System.Windows.Forms;

namespace AppVideoClips
{
    public static class Theme
    {
        public static bool IsDark { get; private set; } = true;

        // темно-синяя тема
        public static readonly Color DarkBackground = Color.FromArgb(10, 15, 30);
        public static readonly Color DarkPanel = Color.FromArgb(18, 24, 40);
        public static readonly Color DarkPanelAlt = Color.FromArgb(16, 22, 36);
        public static readonly Color DarkForeground = Color.FromArgb(230, 230, 230);
        public static readonly Color DarkAccent = Color.FromArgb(48, 84, 145); 
        public static readonly Color DarkIcon = Color.FromArgb(240,240,240);

        // белая тема
        public static readonly Color LightBackground = Color.FromArgb(250, 250, 250);
        public static readonly Color LightPanel = Color.FromArgb(240, 240, 240);
        public static readonly Color LightPanelAlt = Color.FromArgb(230, 230, 230);
        public static readonly Color LightForeground = Color.FromArgb(30, 30, 30);
        public static readonly Color LightAccent = Color.FromArgb(40, 120, 200);
        public static readonly Color LightIcon = Color.FromArgb(60,60,60);

        public static Color Background => IsDark ? DarkBackground : LightBackground;
        public static Color Panel => IsDark ? DarkPanel : LightPanel;
        public static Color PanelAlt => IsDark ? DarkPanelAlt : LightPanelAlt;
        public static Color Foreground => IsDark ? DarkForeground : LightForeground;
        public static Color Accent => IsDark ? DarkAccent : LightAccent;
        public static Color IconColor => IsDark ? DarkIcon : LightIcon;

        public static void ToggleTheme(Control root)
        {
            // рут
            IsDark = !IsDark;
            ApplyTheme(root);
        }

        public static void ToggleThemeGlobal()
        {
            IsDark = !IsDark;
            // Применение ко всем формам 
            foreach (Form f in Application.OpenForms)
            {
                try { ApplyTheme(f); } catch { }
            }
        }

        public static void ApplyTheme(Control root)
        {
            if (root == null) return;
            root.BackColor = Background;
            ApplyToChildren(root);
        }

        private static void ApplyToChildren(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Panel) c.BackColor = Panel;
                else if (c is Button) { c.BackColor = PanelAlt; c.ForeColor = Foreground; }
                else if (c is Label) c.ForeColor = Foreground;
                else if (c is TextBox) { c.BackColor = PanelAlt; c.ForeColor = Foreground; }
                else if (c is DataGridView dgv) { dgv.BackgroundColor = PanelAlt; dgv.DefaultCellStyle.BackColor = PanelAlt; dgv.DefaultCellStyle.ForeColor = Foreground; }
                else c.BackColor = PanelAlt;

                if (c is PictureBox pb) pb.BackColor = Color.Transparent;

                if (c.HasChildren) ApplyToChildren(c);
            }
        }
    }
}