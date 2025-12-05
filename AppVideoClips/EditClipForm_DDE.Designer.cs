namespace AppVideoClips
{
    partial class EditClipForm_DDE
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox textBoxCode_DDE;
        private TextBox textBoxTheme_DDE;
        private NumericUpDown numericDuration_DDE;
        private NumericUpDown numericCost_DDE;
        private DateTimePicker dateTimePickerRecorded_DDE;

        private TextBox textBoxLastName_DDE;
        private TextBox textBoxFirstName_DDE;
        private TextBox textBoxRole_DDE;

        private Button buttonSave_DDE;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxCode_DDE = new TextBox();
            this.textBoxTheme_DDE = new TextBox();
            this.numericDuration_DDE = new NumericUpDown();
            this.numericCost_DDE = new NumericUpDown();
            this.dateTimePickerRecorded_DDE = new DateTimePicker();

            this.textBoxLastName_DDE = new TextBox();
            this.textBoxFirstName_DDE = new TextBox();
            this.textBoxRole_DDE = new TextBox();

            this.buttonSave_DDE = new Button();

            SuspendLayout();

            textBoxCode_DDE.Top = 10;
            textBoxCode_DDE.Left = 10;
            textBoxCode_DDE.Width = 200;
            textBoxCode_DDE.PlaceholderText = "Код видео";

            textBoxTheme_DDE.Top = 40;
            textBoxTheme_DDE.Left = 10;
            textBoxTheme_DDE.Width = 200;
            textBoxTheme_DDE.PlaceholderText = "Тема";

            numericDuration_DDE.Top = 70;
            numericDuration_DDE.Left = 10;
            numericDuration_DDE.Maximum = 10000;

            numericCost_DDE.Top = 100;
            numericCost_DDE.Left = 10;
            numericCost_DDE.Maximum = 1000000;

            dateTimePickerRecorded_DDE.Top = 130;
            dateTimePickerRecorded_DDE.Left = 10;

            textBoxLastName_DDE.Top = 160;
            textBoxLastName_DDE.Left = 10;
            textBoxLastName_DDE.PlaceholderText = "Фамилия";

            textBoxFirstName_DDE.Top = 190;
            textBoxFirstName_DDE.Left = 10;
            textBoxFirstName_DDE.PlaceholderText = "Имя";

            textBoxRole_DDE.Top = 220;
            textBoxRole_DDE.Left = 10;
            textBoxRole_DDE.PlaceholderText = "Амплуа";

            buttonSave_DDE.Text = "Сохранить";
            buttonSave_DDE.Top = 260;
            buttonSave_DDE.Left = 10;
            buttonSave_DDE.Click += buttonSave_DDE_Click;

            Controls.AddRange(new Control[]
            {
                textBoxCode_DDE, textBoxTheme_DDE,
                numericDuration_DDE, numericCost_DDE,
                dateTimePickerRecorded_DDE,
                textBoxLastName_DDE, textBoxFirstName_DDE, textBoxRole_DDE,
                buttonSave_DDE
            });

            Text = "Редактирование клипа";
            ClientSize = new System.Drawing.Size(300, 320);
            ResumeLayout(false);
        }
    }
}
