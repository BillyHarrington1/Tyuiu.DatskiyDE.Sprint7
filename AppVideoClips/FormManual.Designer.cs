namespace AppVideoClips
{
    partial class FormManual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManual));
            rich_DDE = new RichTextBox();
            SuspendLayout();
            // 
            // rich_DDE
            // 
            rich_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            rich_DDE.ForeColor = Color.White;
            rich_DDE.Location = new Point(12, 12);
            rich_DDE.Name = "rich_DDE";
            rich_DDE.Size = new Size(532, 530);
            rich_DDE.TabIndex = 1;
            rich_DDE.Text = resources.GetString("rich_DDE.Text");
            // 
            // FormManual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 550);
            Controls.Add(rich_DDE);
            Name = "FormManual";
            Text = "Guide";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rich_DDE;
    }
}