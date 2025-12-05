using Microsoft.Web.WebView2.WinForms;
namespace AppVideoClips
{
    partial class ClipCardControl_DDE
    {
        private WebView2 webView_DDE;

        private void InitializeComponent()
        {
            webView_DDE = new WebView2();
            SuspendLayout();

            webView_DDE.Dock = DockStyle.Fill;
            webView_DDE.CreationProperties = null;
            webView_DDE.DefaultBackgroundColor = System.Drawing.Color.White;

            Controls.Add(webView_DDE);
            Name = "ClipCardControl_DDE";
            Size = new System.Drawing.Size(320, 200);

            ResumeLayout(false);
        }
    }
}
