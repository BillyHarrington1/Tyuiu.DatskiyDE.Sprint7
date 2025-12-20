using LiveCharts.WinForms;
using LiveChartsCore.SkiaSharpView;

namespace AppVideoClips
{
    partial class FormGraph
    {
        private CartesianChart cartesianChart_DDE;
        private ComboBox comboBoxColumn_DDE;
        private Label labelSelect_DDE;
        private ListBox listBoxIdName_DDE;
        private Panel panelTop_DDE;
        private ComboBox comboBoxOperation_DDE;
        private Label labelOperation_DDE;
        private Button buttonApply_DDE;

        // New UI panels for stylized border
        private Panel panelClient_DDE;
        private Panel panelBorderLeft_DDE;
        private Panel panelBorderRight_DDE;
        private Panel panelBorderTop_DDE;
        private Panel panelBorderBottom_DDE;

        private void InitializeComponent()
        {
            cartesianChart_DDE = new CartesianChart();
            comboBoxColumn_DDE = new ComboBox();
            labelSelect_DDE = new Label();
            listBoxIdName_DDE = new ListBox();
            panelTop_DDE = new Panel();
            labelOperation_DDE = new Label();
            comboBoxOperation_DDE = new ComboBox();
            buttonApply_DDE = new Button();
            panelClient_DDE = new Panel();
            panelBorderLeft_DDE = new Panel();
            panelBorderRight_DDE = new Panel();
            panelBorderTop_DDE = new Panel();
            panelBorderBottom_DDE = new Panel();
            panelTop_DDE.SuspendLayout();
            panelClient_DDE.SuspendLayout();
            SuspendLayout();
            // 
            // cartesianChart_DDE
            // 
            cartesianChart_DDE.BackColor = Color.Transparent;
            cartesianChart_DDE.Dock = DockStyle.Fill;
            cartesianChart_DDE.ForeColor = Color.FromArgb(192, 192, 0);
            cartesianChart_DDE.Location = new Point(266, 54);
            cartesianChart_DDE.Name = "cartesianChart_DDE";
            cartesianChart_DDE.Size = new Size(900, 589);
            cartesianChart_DDE.TabIndex = 0;
            cartesianChart_DDE.ChildChanged += cartesianChart_DDE_ChildChanged;
            // 
            // comboBoxColumn_DDE
            // 
            comboBoxColumn_DDE.BackColor = Color.DarkSlateGray;
            comboBoxColumn_DDE.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColumn_DDE.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            comboBoxColumn_DDE.ForeColor = Color.FromArgb(192, 192, 0);
            comboBoxColumn_DDE.Location = new Point(154, 6);
            comboBoxColumn_DDE.Name = "comboBoxColumn_DDE";
            comboBoxColumn_DDE.Size = new Size(316, 31);
            comboBoxColumn_DDE.TabIndex = 1;
            comboBoxColumn_DDE.SelectedIndexChanged += comboBoxColumn_DDE_SelectedIndexChanged;
            // 
            // labelSelect_DDE
            // 
            labelSelect_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            labelSelect_DDE.Location = new Point(3, 8);
            labelSelect_DDE.Name = "labelSelect_DDE";
            labelSelect_DDE.Size = new Size(140, 28);
            labelSelect_DDE.TabIndex = 0;
            labelSelect_DDE.Text = "Выберите колонку:";
            labelSelect_DDE.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listBoxIdName_DDE
            // 
            listBoxIdName_DDE.BackColor = Color.Gainsboro;
            listBoxIdName_DDE.BorderStyle = BorderStyle.FixedSingle;
            listBoxIdName_DDE.Dock = DockStyle.Left;
            listBoxIdName_DDE.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            listBoxIdName_DDE.ForeColor = Color.FromArgb(192, 192, 0);
            listBoxIdName_DDE.ItemHeight = 33;
            listBoxIdName_DDE.Location = new Point(6, 54);
            listBoxIdName_DDE.Name = "listBoxIdName_DDE";
            listBoxIdName_DDE.Size = new Size(260, 589);
            listBoxIdName_DDE.TabIndex = 1;
            listBoxIdName_DDE.SelectedIndexChanged += listBoxIdName_DDE_SelectedIndexChanged;
            // 
            // panelTop_DDE
            // 
            panelTop_DDE.BackColor = Color.Gray;
            panelTop_DDE.Controls.Add(labelSelect_DDE);
            panelTop_DDE.Controls.Add(comboBoxColumn_DDE);
            panelTop_DDE.Controls.Add(labelOperation_DDE);
            panelTop_DDE.Controls.Add(comboBoxOperation_DDE);
            panelTop_DDE.Controls.Add(buttonApply_DDE);
            panelTop_DDE.Dock = DockStyle.Top;
            panelTop_DDE.Location = new Point(6, 6);
            panelTop_DDE.Name = "panelTop_DDE";
            panelTop_DDE.Padding = new Padding(8);
            panelTop_DDE.Size = new Size(1160, 48);
            panelTop_DDE.TabIndex = 2;
            // 
            // labelOperation_DDE
            // 
            labelOperation_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic);
            labelOperation_DDE.Location = new Point(492, 8);
            labelOperation_DDE.Name = "labelOperation_DDE";
            labelOperation_DDE.Size = new Size(84, 28);
            labelOperation_DDE.TabIndex = 2;
            labelOperation_DDE.Text = "Операция:";
            labelOperation_DDE.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxOperation_DDE
            // 
            comboBoxOperation_DDE.BackColor = Color.DarkSlateGray;
            comboBoxOperation_DDE.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperation_DDE.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            comboBoxOperation_DDE.ForeColor = Color.FromArgb(192, 192, 0);
            comboBoxOperation_DDE.Location = new Point(582, 6);
            comboBoxOperation_DDE.Name = "comboBoxOperation_DDE";
            comboBoxOperation_DDE.Size = new Size(226, 31);
            comboBoxOperation_DDE.TabIndex = 3;
            // 
            // buttonApply_DDE
            // 
            buttonApply_DDE.AutoSize = true;
            buttonApply_DDE.BackColor = Color.DimGray;
            buttonApply_DDE.FlatStyle = FlatStyle.Popup;
            buttonApply_DDE.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonApply_DDE.Location = new Point(820, 6);
            buttonApply_DDE.Name = "buttonApply_DDE";
            buttonApply_DDE.Size = new Size(352, 31);
            buttonApply_DDE.TabIndex = 4;
            buttonApply_DDE.Text = "Применить";
            buttonApply_DDE.UseVisualStyleBackColor = false;
            buttonApply_DDE.Click += buttonApply_DDE_Click;
            // 
            // panelClient_DDE
            // 
            panelClient_DDE.Controls.Add(cartesianChart_DDE);
            panelClient_DDE.Controls.Add(listBoxIdName_DDE);
            panelClient_DDE.Controls.Add(panelTop_DDE);
            panelClient_DDE.Dock = DockStyle.Fill;
            panelClient_DDE.Location = new Point(6, 6);
            panelClient_DDE.Name = "panelClient_DDE";
            panelClient_DDE.Padding = new Padding(6);
            panelClient_DDE.Size = new Size(1172, 649);
            panelClient_DDE.TabIndex = 0;
            // 
            // panelBorderLeft_DDE
            // 
            panelBorderLeft_DDE.BackColor = Color.FromArgb(40, 40, 40);
            panelBorderLeft_DDE.Dock = DockStyle.Left;
            panelBorderLeft_DDE.Location = new Point(0, 6);
            panelBorderLeft_DDE.Name = "panelBorderLeft_DDE";
            panelBorderLeft_DDE.Size = new Size(6, 649);
            panelBorderLeft_DDE.TabIndex = 1;
            // 
            // panelBorderRight_DDE
            // 
            panelBorderRight_DDE.BackColor = Color.FromArgb(40, 40, 40);
            panelBorderRight_DDE.Dock = DockStyle.Right;
            panelBorderRight_DDE.Location = new Point(1178, 6);
            panelBorderRight_DDE.Name = "panelBorderRight_DDE";
            panelBorderRight_DDE.Size = new Size(6, 649);
            panelBorderRight_DDE.TabIndex = 2;
            // 
            // panelBorderTop_DDE
            // 
            panelBorderTop_DDE.BackColor = Color.FromArgb(40, 40, 40);
            panelBorderTop_DDE.Dock = DockStyle.Top;
            panelBorderTop_DDE.Location = new Point(0, 0);
            panelBorderTop_DDE.Name = "panelBorderTop_DDE";
            panelBorderTop_DDE.Size = new Size(1184, 6);
            panelBorderTop_DDE.TabIndex = 3;
            // 
            // panelBorderBottom_DDE
            // 
            panelBorderBottom_DDE.BackColor = Color.FromArgb(40, 40, 40);
            panelBorderBottom_DDE.Dock = DockStyle.Bottom;
            panelBorderBottom_DDE.Location = new Point(0, 655);
            panelBorderBottom_DDE.Name = "panelBorderBottom_DDE";
            panelBorderBottom_DDE.Size = new Size(1184, 6);
            panelBorderBottom_DDE.TabIndex = 4;
            // 
            // FormGraph
            // 
            ClientSize = new Size(1184, 661);
            Controls.Add(panelClient_DDE);
            Controls.Add(panelBorderLeft_DDE);
            Controls.Add(panelBorderRight_DDE);
            Controls.Add(panelBorderTop_DDE);
            Controls.Add(panelBorderBottom_DDE);
            Font = new Font("Segoe Print", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            Name = "FormGraph";
            Text = "Статистика";
            Load += FormGraph_Load;
            panelTop_DDE.ResumeLayout(false);
            panelTop_DDE.PerformLayout();
            panelClient_DDE.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
