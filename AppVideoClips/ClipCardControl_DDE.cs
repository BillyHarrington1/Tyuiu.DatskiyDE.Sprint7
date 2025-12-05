using System;
using System.Windows.Forms;
using AppVideoClips.Lib;
using Microsoft.Web.WebView2.WinForms;

namespace AppVideoClips
{
    public partial class ClipCardControl_DDE : UserControl
    {
        private VideoClip _clip;

        public ClipCardControl_DDE()
        {
            InitializeComponent();
        }

        public void Bind(VideoClip clip)
        {
            _clip = clip;

            // Try to derive a YouTube id from clip.Code if possible
            string? youTubeId = null;
            if (!string.IsNullOrWhiteSpace(clip.Code))
            {
                var code = clip.Code.Trim();

                // If code looks like a full YouTube URL, try to extract id
                if (code.Contains("youtu"))
                {
                    try
                    {
                        // common patterns: v=ID or youtu.be/ID or /embed/ID
                        var uri = new Uri(code);
                        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                        if (query.AllKeys.Contains("v"))
                        {
                            youTubeId = query["v"];
                        }
                        else
                        {
                            // take last segment
                            var seg = uri.Segments;
                            if (seg.Length > 0)
                                youTubeId = seg[^1].Trim('/');
                        }
                    }
                    catch
                    {
                        // fallback to raw code
                        youTubeId = code;
                    }
                }
                else
                {
                    // If code looks like an id (length between 8 and 64), treat it as id
                    if (code.Length >= 8 && code.Length <= 64)
                        youTubeId = code;
                }
            }

            if (!string.IsNullOrWhiteSpace(youTubeId))
            {
                try
                {
                    webView_DDE.Source = new Uri($"https://www.youtube.com/embed/{youTubeId}");
                }
                catch
                {
                    // ignore invalid URIs
                }
            }
            else
            {
                // nothing to show
                try
                {
                    webView_DDE.Source = new Uri("about:blank");
                }
                catch { }
            }
        }
    }
}
