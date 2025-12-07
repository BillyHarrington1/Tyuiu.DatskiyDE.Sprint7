namespace AppVideoClips
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }




        private void buttonGo_GAM_Click(object sender, EventArgs e)
        {
            this.Visible = false;




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
            Application.Exit();




        }
    }
}
