namespace AppVideoClips
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var menu = new FormMenu())
                {
                    // Menu is modal; DialogResult determines action
                    var dr = menu.ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        // Exit selected
                        break;
                    }
                }

                // User chose to go to main workspace — run main form until it closes
                using (var main = new FormMain())
                {
                    Application.Run(main);
                }

                // After FormMain closes, loop back to show the menu again
            }
        }
    }
}