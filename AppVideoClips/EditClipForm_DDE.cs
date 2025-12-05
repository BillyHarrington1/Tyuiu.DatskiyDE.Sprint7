using System;
using System.Windows.Forms;
using AppVideoClips.Lib;

namespace AppVideoClips
{
    public partial class EditClipForm_DDE : Form
    {
        public VideoClip Clip { get; private set; }

        public EditClipForm_DDE()
        {
            InitializeComponent();
            Clip = new VideoClip();
        }

        public EditClipForm_DDE(VideoClip clip)
        {
            InitializeComponent();
            Clip = clip;

            textBoxCode_DDE.Text = clip.Code;
            textBoxTheme_DDE.Text = clip.Theme;
            numericDuration_DDE.Value = clip.DurationSeconds;
            numericCost_DDE.Value = clip.Cost;
            dateTimePickerRecorded_DDE.Value = clip.RecordedDate;

            textBoxLastName_DDE.Text = clip.ActorLastName;
            textBoxFirstName_DDE.Text = clip.ActorFirstName;
            textBoxRole_DDE.Text = clip.ActorRole;
        }

        private void buttonSave_DDE_Click(object sender, EventArgs e)
        {
            Clip.Code = textBoxCode_DDE.Text;
            Clip.Theme = textBoxTheme_DDE.Text;
            Clip.DurationSeconds = (int)numericDuration_DDE.Value;
            Clip.Cost = numericCost_DDE.Value;
            Clip.RecordedDate = dateTimePickerRecorded_DDE.Value;

            Clip.ActorLastName = textBoxLastName_DDE.Text;
            Clip.ActorFirstName = textBoxFirstName_DDE.Text;
            Clip.ActorRole = textBoxRole_DDE.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
