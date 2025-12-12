namespace AppVideoClips
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            openFileDialogMain_DDE = new OpenFileDialog();
            panelUpper_DDE = new Panel();
            buttonCloseCustom = new Button();
            buttonMinimize_DDE = new Button();
            buttonTheme_DDE = new Button();
            buttonMenu_DDE = new Button();
            pictureBoxSort_DDE = new PictureBox();
            buttonReset_DDE = new Button();
            menuStripSort_DDE = new MenuStrip();
            toolStripMenuItemMain_DDE = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_SortDuration = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_ColumnWeight = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_ColumnID = new ToolStripMenuItem();
            ToolStripMenuItem_DDE = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_ColumnDuration_Dec = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_ColumnWeight_Dec = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_ColumnID_Dec = new ToolStripMenuItem();
            pictureBoxAbout_DDE = new PictureBox();
            pictureBoxSave_DDE = new PictureBox();
            pictureBoxManagement_DDE = new PictureBox();
            pictureBoxLoad_DDE = new PictureBox();
            buttonAbout_DDE = new Button();
            buttonSave_DDE = new Button();
            buttonManagement_DDE = new Button();
            buttonLoad_DDE = new Button();
            panelDown_DDE = new Panel();
            buttonGraph_DDE = new Button();
            textBoxFilter_DDE = new TextBox();
            textBoxSearch_DDE = new TextBox();
            buttonSearch_DDE = new Button();
            pictureBoxSearch_DDE = new PictureBox();
            pictureBoxFilter_DDE = new PictureBox();
            menuStripMain_DDE = new MenuStrip();
            фильтрToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_FilterName = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_FilterWeight = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_FilterDuration = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_FilterFormat = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_FilterCategory = new ToolStripMenuItem();
            ToolStripMenuItem_DDE_FilterID = new ToolStripMenuItem();
            panelMiddle_DDE = new Panel();
            groupBoxBase_DDE = new GroupBox();
            dataGridViewBase_DDE = new DataGridView();
            saveFileDialogMain_DDE = new SaveFileDialog();
            toolTipButtons_DDE = new ToolTip(components);
            panelUpper_DDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSort_DDE).BeginInit();
            menuStripSort_DDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAbout_DDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSave_DDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxManagement_DDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoad_DDE).BeginInit();
            panelDown_DDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch_DDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFilter_DDE).BeginInit();
            menuStripMain_DDE.SuspendLayout();
            panelMiddle_DDE.SuspendLayout();
            groupBoxBase_DDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBase_DDE).BeginInit();
            SuspendLayout();
            // 
            // openFileDialogMain_DDE
            // 
            openFileDialogMain_DDE.FileName = "openFileDialog1";
            // 
            // panelUpper_DDE
            // 
            panelUpper_DDE.BackColor = Color.FromArgb(60, 60, 60);
            panelUpper_DDE.Controls.Add(buttonCloseCustom);
            panelUpper_DDE.Controls.Add(buttonMinimize_DDE);
            panelUpper_DDE.Controls.Add(buttonTheme_DDE);
            panelUpper_DDE.Controls.Add(buttonMenu_DDE);
            panelUpper_DDE.Controls.Add(pictureBoxSort_DDE);
            panelUpper_DDE.Controls.Add(buttonReset_DDE);
            panelUpper_DDE.Controls.Add(menuStripSort_DDE);
            panelUpper_DDE.Controls.Add(pictureBoxAbout_DDE);
            panelUpper_DDE.Controls.Add(pictureBoxSave_DDE);
            panelUpper_DDE.Controls.Add(pictureBoxManagement_DDE);
            panelUpper_DDE.Controls.Add(pictureBoxLoad_DDE);
            panelUpper_DDE.Controls.Add(buttonAbout_DDE);
            panelUpper_DDE.Controls.Add(buttonSave_DDE);
            panelUpper_DDE.Controls.Add(buttonManagement_DDE);
            panelUpper_DDE.Controls.Add(buttonLoad_DDE);
            panelUpper_DDE.Dock = DockStyle.Top;
            panelUpper_DDE.Location = new Point(0, 0);
            panelUpper_DDE.Margin = new Padding(4, 3, 4, 3);
            panelUpper_DDE.Name = "panelUpper_DDE";
            panelUpper_DDE.Size = new Size(938, 97);
            panelUpper_DDE.TabIndex = 0;
            // 
            // buttonCloseCustom
            // 
            buttonCloseCustom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCloseCustom.BackColor = Color.FromArgb(40, 40, 40);
            buttonCloseCustom.FlatStyle = FlatStyle.Popup;
            buttonCloseCustom.ForeColor = Color.WhiteSmoke;
            buttonCloseCustom.Location = new Point(818, 7);
            buttonCloseCustom.Name = "buttonCloseCustom";
            buttonCloseCustom.Size = new Size(108, 39);
            buttonCloseCustom.TabIndex = 7;
            buttonCloseCustom.Text = "Закрыть";
            buttonCloseCustom.UseVisualStyleBackColor = false;
            buttonCloseCustom.Click += ButtonCloseCustom_Click;
            // 
            // buttonMinimize_DDE
            // 
            buttonMinimize_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMinimize_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonMinimize_DDE.FlatStyle = FlatStyle.Popup;
            buttonMinimize_DDE.ForeColor = Color.WhiteSmoke;
            buttonMinimize_DDE.Location = new Point(702, 7);
            buttonMinimize_DDE.Name = "buttonMinimize_DDE";
            buttonMinimize_DDE.Size = new Size(108, 39);
            buttonMinimize_DDE.TabIndex = 8;
            buttonMinimize_DDE.Text = "Свернуть";
            buttonMinimize_DDE.UseVisualStyleBackColor = false;
            buttonMinimize_DDE.Click += ButtonMinimize_DDE_Click;
            // 
            // buttonTheme_DDE
            // 
            buttonTheme_DDE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTheme_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonTheme_DDE.FlatStyle = FlatStyle.Popup;
            buttonTheme_DDE.ForeColor = Color.WhiteSmoke;
            buttonTheme_DDE.Location = new Point(590, 7);
            buttonTheme_DDE.Name = "buttonTheme_DDE";
            buttonTheme_DDE.Size = new Size(108, 39);
            buttonTheme_DDE.TabIndex = 9;
            buttonTheme_DDE.Text = "Тема";
            buttonTheme_DDE.UseVisualStyleBackColor = false;
            buttonTheme_DDE.Click += ButtonTheme_DDE_Click;
            // 
            // buttonMenu_DDE
            // 
            buttonMenu_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonMenu_DDE.FlatStyle = FlatStyle.Popup;
            buttonMenu_DDE.ForeColor = Color.WhiteSmoke;
            buttonMenu_DDE.Location = new Point(6, 53);
            buttonMenu_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonMenu_DDE.Name = "buttonMenu_DDE";
            buttonMenu_DDE.Size = new Size(154, 39);
            buttonMenu_DDE.TabIndex = 6;
            buttonMenu_DDE.Text = "Главное меню";
            toolTipButtons_DDE.SetToolTip(buttonMenu_DDE, "Вернуться в главное меню");
            buttonMenu_DDE.UseVisualStyleBackColor = false;
            buttonMenu_DDE.Click += buttonMenu_DDE_Click;
            buttonMenu_DDE.MouseEnter += buttonMenu_DDE_MouseEnter;
            buttonMenu_DDE.MouseLeave += buttonMenu_DDE_MouseLeave;
            // 
            // pictureBoxSort_DDE
            // 
            pictureBoxSort_DDE.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxSort_DDE.Location = new Point(650, 63);
            pictureBoxSort_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSort_DDE.Name = "pictureBoxSort_DDE";
            pictureBoxSort_DDE.Size = new Size(34, 33);
            pictureBoxSort_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSort_DDE.TabIndex = 5;
            pictureBoxSort_DDE.TabStop = false;
            pictureBoxSort_DDE.Click += pictureBoxSort_DDE_Click;
            // 
            // buttonReset_DDE
            // 
            buttonReset_DDE.BackColor = Color.Transparent;
            buttonReset_DDE.BackgroundImageLayout = ImageLayout.Zoom;
            buttonReset_DDE.Enabled = false;
            buttonReset_DDE.FlatAppearance.BorderSize = 0;
            buttonReset_DDE.FlatStyle = FlatStyle.Flat;
            buttonReset_DDE.Location = new Point(355, 7);
            buttonReset_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonReset_DDE.Name = "buttonReset_DDE";
            buttonReset_DDE.Size = new Size(37, 37);
            buttonReset_DDE.TabIndex = 4;
            toolTipButtons_DDE.SetToolTip(buttonReset_DDE, "Вернуть таблицу к исходному виду");
            buttonReset_DDE.UseVisualStyleBackColor = false;
            buttonReset_DDE.Click += buttonReset_DDE_Click;
            buttonReset_DDE.MouseEnter += buttonReset_DDE_MouseEnter;
            buttonReset_DDE.MouseLeave += buttonReset_DDE_MouseLeave;
            // 
            // menuStripSort_DDE
            // 
            menuStripSort_DDE.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            menuStripSort_DDE.BackColor = Color.FromArgb(120, 120, 120);
            menuStripSort_DDE.Dock = DockStyle.None;
            menuStripSort_DDE.Items.AddRange(new ToolStripItem[] { toolStripMenuItemMain_DDE, ToolStripMenuItem_DDE });
            menuStripSort_DDE.Location = new Point(699, 68);
            menuStripSort_DDE.Name = "menuStripSort_DDE";
            menuStripSort_DDE.Padding = new Padding(7, 2, 0, 2);
            menuStripSort_DDE.Size = new Size(215, 24);
            menuStripSort_DDE.TabIndex = 3;
            menuStripSort_DDE.Text = "menuStrip";
            // 
            // toolStripMenuItemMain_DDE
            // 
            toolStripMenuItemMain_DDE.BackColor = Color.FromArgb(120, 120, 120);
            toolStripMenuItemMain_DDE.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_DDE_SortDuration, ToolStripMenuItem_DDE_ColumnWeight, ToolStripMenuItem_DDE_ColumnID });
            toolStripMenuItemMain_DDE.ForeColor = SystemColors.ControlText;
            toolStripMenuItemMain_DDE.Name = "toolStripMenuItemMain_DDE";
            toolStripMenuItemMain_DDE.Size = new Size(110, 20);
            toolStripMenuItemMain_DDE.Text = "По возрастанию";
            // 
            // ToolStripMenuItem_DDE_SortDuration
            // 
            ToolStripMenuItem_DDE_SortDuration.Name = "ToolStripMenuItem_DDE_SortDuration";
            ToolStripMenuItem_DDE_SortDuration.Size = new Size(211, 22);
            ToolStripMenuItem_DDE_SortDuration.Text = "Столбец \"Длительность\"";
            ToolStripMenuItem_DDE_SortDuration.Click += сортировкаToolStripMenuItem_Click_1;
            // 
            // ToolStripMenuItem_DDE_ColumnWeight
            // 
            ToolStripMenuItem_DDE_ColumnWeight.Name = "ToolStripMenuItem_DDE_ColumnWeight";
            ToolStripMenuItem_DDE_ColumnWeight.Size = new Size(211, 22);
            ToolStripMenuItem_DDE_ColumnWeight.Text = "Столбец \"Вес\"";
            ToolStripMenuItem_DDE_ColumnWeight.Click += столбецВесToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_ColumnID
            // 
            ToolStripMenuItem_DDE_ColumnID.Name = "ToolStripMenuItem_DDE_ColumnID";
            ToolStripMenuItem_DDE_ColumnID.Size = new Size(211, 22);
            ToolStripMenuItem_DDE_ColumnID.Text = "Столбец \"ID\"";
            ToolStripMenuItem_DDE_ColumnID.Click += столбецIDToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE
            // 
            ToolStripMenuItem_DDE.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_DDE_ColumnDuration_Dec, ToolStripMenuItem_DDE_ColumnWeight_Dec, ToolStripMenuItem_DDE_ColumnID_Dec });
            ToolStripMenuItem_DDE.ForeColor = SystemColors.ControlText;
            ToolStripMenuItem_DDE.Name = "ToolStripMenuItem_DDE";
            ToolStripMenuItem_DDE.Size = new Size(96, 20);
            ToolStripMenuItem_DDE.Text = "По убыванию";
            // 
            // ToolStripMenuItem_DDE_ColumnDuration_Dec
            // 
            ToolStripMenuItem_DDE_ColumnDuration_Dec.Name = "ToolStripMenuItem_DDE_ColumnDuration_Dec";
            ToolStripMenuItem_DDE_ColumnDuration_Dec.Size = new Size(211, 22);
            ToolStripMenuItem_DDE_ColumnDuration_Dec.Text = "Столбец \"Длительность\"";
            ToolStripMenuItem_DDE_ColumnDuration_Dec.Click += столбецДлительностьToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_ColumnWeight_Dec
            // 
            ToolStripMenuItem_DDE_ColumnWeight_Dec.Name = "ToolStripMenuItem_DDE_ColumnWeight_Dec";
            ToolStripMenuItem_DDE_ColumnWeight_Dec.Size = new Size(211, 22);
            ToolStripMenuItem_DDE_ColumnWeight_Dec.Text = "Столбец \"Вес\"";
            ToolStripMenuItem_DDE_ColumnWeight_Dec.Click += столбецВесToolStripMenuItem1_Click;
            // 
            // ToolStripMenuItem_DDE_ColumnID_Dec
            // 
            ToolStripMenuItem_DDE_ColumnID_Dec.Name = "ToolStripMenuItem_DDE_ColumnID_Dec";
            ToolStripMenuItem_DDE_ColumnID_Dec.Size = new Size(211, 22);
            ToolStripMenuItem_DDE_ColumnID_Dec.Text = "Столбец \"ID\"";
            ToolStripMenuItem_DDE_ColumnID_Dec.Click += столбецДатаToolStripMenuItem1_Click;
            // 
            // pictureBoxAbout_DDE
            // 
            pictureBoxAbout_DDE.Anchor = AnchorStyles.Right;
            pictureBoxAbout_DDE.BackColor = Color.Transparent;
            pictureBoxAbout_DDE.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxAbout_DDE.ErrorImage = null;
            pictureBoxAbout_DDE.InitialImage = null;
            pictureBoxAbout_DDE.Location = new Point(644, 7);
            pictureBoxAbout_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxAbout_DDE.Name = "pictureBoxAbout_DDE";
            pictureBoxAbout_DDE.Size = new Size(40, 39);
            pictureBoxAbout_DDE.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxAbout_DDE.TabIndex = 1;
            pictureBoxAbout_DDE.TabStop = false;
            // 
            // pictureBoxSave_DDE
            // 
            pictureBoxSave_DDE.BackColor = Color.Transparent;
            pictureBoxSave_DDE.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSave_DDE.ErrorImage = null;
            pictureBoxSave_DDE.InitialImage = null;
            pictureBoxSave_DDE.Location = new Point(176, 7);
            pictureBoxSave_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSave_DDE.Name = "pictureBoxSave_DDE";
            pictureBoxSave_DDE.Size = new Size(40, 39);
            pictureBoxSave_DDE.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSave_DDE.TabIndex = 1;
            pictureBoxSave_DDE.TabStop = false;
            // 
            // pictureBoxManagement_DDE
            // 
            pictureBoxManagement_DDE.Anchor = AnchorStyles.Right;
            pictureBoxManagement_DDE.BackColor = Color.Transparent;
            pictureBoxManagement_DDE.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxManagement_DDE.ErrorImage = null;
            pictureBoxManagement_DDE.InitialImage = null;
            pictureBoxManagement_DDE.Location = new Point(475, 5);
            pictureBoxManagement_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxManagement_DDE.Name = "pictureBoxManagement_DDE";
            pictureBoxManagement_DDE.Size = new Size(40, 39);
            pictureBoxManagement_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxManagement_DDE.TabIndex = 1;
            pictureBoxManagement_DDE.TabStop = false;
            // 
            // pictureBoxLoad_DDE
            // 
            pictureBoxLoad_DDE.BackColor = Color.Transparent;
            pictureBoxLoad_DDE.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxLoad_DDE.ErrorImage = null;
            pictureBoxLoad_DDE.InitialImage = null;
            pictureBoxLoad_DDE.Location = new Point(4, 7);
            pictureBoxLoad_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxLoad_DDE.Name = "pictureBoxLoad_DDE";
            pictureBoxLoad_DDE.Size = new Size(40, 39);
            pictureBoxLoad_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLoad_DDE.TabIndex = 1;
            pictureBoxLoad_DDE.TabStop = false;
            // 
            // buttonAbout_DDE
            // 
            buttonAbout_DDE.Anchor = AnchorStyles.Right;
            buttonAbout_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonAbout_DDE.FlatStyle = FlatStyle.Popup;
            buttonAbout_DDE.Font = new Font("Segoe UI", 9F);
            buttonAbout_DDE.ForeColor = Color.WhiteSmoke;
            buttonAbout_DDE.Location = new Point(692, 7);
            buttonAbout_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonAbout_DDE.Name = "buttonAbout_DDE";
            buttonAbout_DDE.Size = new Size(108, 39);
            buttonAbout_DDE.TabIndex = 0;
            buttonAbout_DDE.Text = "О программе";
            toolTipButtons_DDE.SetToolTip(buttonAbout_DDE, "Информация о разработчике");
            buttonAbout_DDE.UseVisualStyleBackColor = false;
            buttonAbout_DDE.Click += buttonAbout_DDE_Click;
            buttonAbout_DDE.MouseEnter += buttonAbout_DDE_MouseEnter;
            buttonAbout_DDE.MouseLeave += buttonAbout_DDE_MouseLeave;
            // 
            // buttonSave_DDE
            // 
            buttonSave_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonSave_DDE.FlatStyle = FlatStyle.Popup;
            buttonSave_DDE.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSave_DDE.ForeColor = Color.WhiteSmoke;
            buttonSave_DDE.Location = new Point(223, 7);
            buttonSave_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonSave_DDE.Name = "buttonSave_DDE";
            buttonSave_DDE.Size = new Size(125, 39);
            buttonSave_DDE.TabIndex = 0;
            buttonSave_DDE.Text = "Сохранить файл";
            toolTipButtons_DDE.SetToolTip(buttonSave_DDE, "Сохранить измененный файл");
            buttonSave_DDE.UseVisualStyleBackColor = false;
            buttonSave_DDE.Click += buttonSave_DDE_Click;
            buttonSave_DDE.MouseEnter += buttonSave_DDE_MouseEnter;
            buttonSave_DDE.MouseLeave += buttonSave_DDE_MouseLeave;
            // 
            // buttonManagement_DDE
            // 
            buttonManagement_DDE.Anchor = AnchorStyles.Right;
            buttonManagement_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonManagement_DDE.FlatStyle = FlatStyle.Popup;
            buttonManagement_DDE.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonManagement_DDE.ForeColor = Color.WhiteSmoke;
            buttonManagement_DDE.Location = new Point(523, 5);
            buttonManagement_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonManagement_DDE.Name = "buttonManagement_DDE";
            buttonManagement_DDE.Size = new Size(100, 39);
            buttonManagement_DDE.TabIndex = 0;
            buttonManagement_DDE.Text = "Руководство";
            toolTipButtons_DDE.SetToolTip(buttonManagement_DDE, "Открыть краткое руководство по программе");
            buttonManagement_DDE.UseVisualStyleBackColor = false;
            buttonManagement_DDE.Click += buttonManagement_DDE_Click;
            buttonManagement_DDE.MouseEnter += buttonManagement_DDE_MouseEnter;
            buttonManagement_DDE.MouseLeave += buttonManagement_DDE_MouseLeave;
            // 
            // buttonLoad_DDE
            // 
            buttonLoad_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonLoad_DDE.FlatStyle = FlatStyle.Popup;
            buttonLoad_DDE.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLoad_DDE.ForeColor = Color.WhiteSmoke;
            buttonLoad_DDE.Location = new Point(48, 7);
            buttonLoad_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonLoad_DDE.Name = "buttonLoad_DDE";
            buttonLoad_DDE.Size = new Size(121, 39);
            buttonLoad_DDE.TabIndex = 0;
            buttonLoad_DDE.Text = "Выбрать файл";
            toolTipButtons_DDE.SetToolTip(buttonLoad_DDE, "Открыть нужный файл для работы");
            buttonLoad_DDE.UseVisualStyleBackColor = false;
            buttonLoad_DDE.Click += buttonLoad_DDE_Click;
            buttonLoad_DDE.MouseEnter += buttonLoad_DDE_MouseEnter;
            buttonLoad_DDE.MouseLeave += buttonLoad_DDE_MouseLeave;
            // 
            // panelDown_DDE
            // 
            panelDown_DDE.BackColor = Color.FromArgb(60, 60, 60);
            panelDown_DDE.Controls.Add(buttonGraph_DDE);
            panelDown_DDE.Controls.Add(textBoxFilter_DDE);
            panelDown_DDE.Controls.Add(textBoxSearch_DDE);
            panelDown_DDE.Controls.Add(buttonSearch_DDE);
            panelDown_DDE.Controls.Add(pictureBoxSearch_DDE);
            panelDown_DDE.Controls.Add(pictureBoxFilter_DDE);
            panelDown_DDE.Controls.Add(menuStripMain_DDE);
            panelDown_DDE.Dock = DockStyle.Bottom;
            panelDown_DDE.Location = new Point(0, 475);
            panelDown_DDE.Margin = new Padding(4, 3, 4, 3);
            panelDown_DDE.Name = "panelDown_DDE";
            panelDown_DDE.Size = new Size(938, 57);
            panelDown_DDE.TabIndex = 1;
            // 
            // buttonGraph_DDE
            // 
            buttonGraph_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonGraph_DDE.FlatStyle = FlatStyle.Popup;
            buttonGraph_DDE.Font = new Font("Segoe UI", 9F);
            buttonGraph_DDE.ForeColor = Color.WhiteSmoke;
            buttonGraph_DDE.Location = new Point(547, 8);
            buttonGraph_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonGraph_DDE.Name = "buttonGraph_DDE";
            buttonGraph_DDE.Size = new Size(88, 38);
            buttonGraph_DDE.TabIndex = 3;
            buttonGraph_DDE.Text = "График";
            toolTipButtons_DDE.SetToolTip(buttonGraph_DDE, "Перейти в среду для отображения графиков");
            buttonGraph_DDE.UseVisualStyleBackColor = false;
            buttonGraph_DDE.Click += buttonGraph_DDE_Click;
            buttonGraph_DDE.MouseEnter += buttonGraph_DDE_MouseEnter;
            buttonGraph_DDE.MouseLeave += buttonGraph_DDE_MouseLeave;
            // 
            // textBoxFilter_DDE
            // 
            textBoxFilter_DDE.BackColor = Color.DarkGray;
            textBoxFilter_DDE.BorderStyle = BorderStyle.FixedSingle;
            textBoxFilter_DDE.Font = new Font("Segoe UI", 9F);
            textBoxFilter_DDE.ForeColor = SystemColors.ControlText;
            textBoxFilter_DDE.Location = new Point(131, 8);
            textBoxFilter_DDE.Margin = new Padding(4, 3, 4, 3);
            textBoxFilter_DDE.Multiline = true;
            textBoxFilter_DDE.Name = "textBoxFilter_DDE";
            textBoxFilter_DDE.Size = new Size(129, 38);
            textBoxFilter_DDE.TabIndex = 2;
            // 
            // textBoxSearch_DDE
            // 
            textBoxSearch_DDE.BackColor = Color.DarkGray;
            textBoxSearch_DDE.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch_DDE.Font = new Font("Segoe UI", 9F);
            textBoxSearch_DDE.ForeColor = SystemColors.ControlText;
            textBoxSearch_DDE.Location = new Point(410, 8);
            textBoxSearch_DDE.Margin = new Padding(4, 3, 4, 3);
            textBoxSearch_DDE.Multiline = true;
            textBoxSearch_DDE.Name = "textBoxSearch_DDE";
            textBoxSearch_DDE.Size = new Size(129, 38);
            textBoxSearch_DDE.TabIndex = 2;
            // 
            // buttonSearch_DDE
            // 
            buttonSearch_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonSearch_DDE.FlatStyle = FlatStyle.Popup;
            buttonSearch_DDE.Font = new Font("Segoe UI", 9F);
            buttonSearch_DDE.ForeColor = Color.WhiteSmoke;
            buttonSearch_DDE.Location = new Point(317, 7);
            buttonSearch_DDE.Margin = new Padding(4, 3, 4, 3);
            buttonSearch_DDE.Name = "buttonSearch_DDE";
            buttonSearch_DDE.Size = new Size(88, 39);
            buttonSearch_DDE.TabIndex = 0;
            buttonSearch_DDE.Text = "Поиск";
            toolTipButtons_DDE.SetToolTip(buttonSearch_DDE, "Выполнить поиск по заданному тексту");
            buttonSearch_DDE.UseVisualStyleBackColor = false;
            buttonSearch_DDE.Click += buttonSearch_DDE_Click;
            buttonSearch_DDE.MouseEnter += buttonSearch_DDE_MouseEnter;
            buttonSearch_DDE.MouseLeave += buttonSearch_DDE_MouseLeave;
            // 
            // pictureBoxSearch_DDE
            // 
            pictureBoxSearch_DDE.BackColor = Color.Transparent;
            pictureBoxSearch_DDE.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch_DDE.ErrorImage = null;
            pictureBoxSearch_DDE.InitialImage = null;
            pictureBoxSearch_DDE.Location = new Point(271, 7);
            pictureBoxSearch_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSearch_DDE.Name = "pictureBoxSearch_DDE";
            pictureBoxSearch_DDE.Size = new Size(40, 39);
            pictureBoxSearch_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSearch_DDE.TabIndex = 1;
            pictureBoxSearch_DDE.TabStop = false;
            // 
            // pictureBoxFilter_DDE
            // 
            pictureBoxFilter_DDE.BackColor = Color.Transparent;
            pictureBoxFilter_DDE.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxFilter_DDE.ErrorImage = null;
            pictureBoxFilter_DDE.InitialImage = null;
            pictureBoxFilter_DDE.Location = new Point(4, 7);
            pictureBoxFilter_DDE.Margin = new Padding(4, 3, 4, 3);
            pictureBoxFilter_DDE.Name = "pictureBoxFilter_DDE";
            pictureBoxFilter_DDE.Size = new Size(40, 39);
            pictureBoxFilter_DDE.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxFilter_DDE.TabIndex = 1;
            pictureBoxFilter_DDE.TabStop = false;
            // 
            // menuStripMain_DDE
            // 
            menuStripMain_DDE.BackColor = Color.FromArgb(120, 120, 120);
            menuStripMain_DDE.BackgroundImageLayout = ImageLayout.Stretch;
            menuStripMain_DDE.Dock = DockStyle.None;
            menuStripMain_DDE.Items.AddRange(new ToolStripItem[] { фильтрToolStripMenuItem });
            menuStripMain_DDE.Location = new Point(48, 13);
            menuStripMain_DDE.Name = "menuStripMain_DDE";
            menuStripMain_DDE.Padding = new Padding(7, 2, 0, 2);
            menuStripMain_DDE.Size = new Size(69, 24);
            menuStripMain_DDE.TabIndex = 4;
            // 
            // фильтрToolStripMenuItem
            // 
            фильтрToolStripMenuItem.BackColor = Color.FromArgb(120, 120, 120);
            фильтрToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_DDE_FilterName, ToolStripMenuItem_DDE_FilterWeight, ToolStripMenuItem_DDE_FilterDuration, ToolStripMenuItem_DDE_FilterFormat, ToolStripMenuItem_DDE_FilterCategory, ToolStripMenuItem_DDE_FilterID });
            фильтрToolStripMenuItem.ForeColor = SystemColors.ControlText;
            фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            фильтрToolStripMenuItem.Size = new Size(60, 20);
            фильтрToolStripMenuItem.Text = "Фильтр";
            // 
            // ToolStripMenuItem_DDE_FilterName
            // 
            ToolStripMenuItem_DDE_FilterName.Name = "ToolStripMenuItem_DDE_FilterName";
            ToolStripMenuItem_DDE_FilterName.Size = new Size(151, 22);
            ToolStripMenuItem_DDE_FilterName.Text = "Название";
            ToolStripMenuItem_DDE_FilterName.Click += названиеToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_FilterWeight
            // 
            ToolStripMenuItem_DDE_FilterWeight.Name = "ToolStripMenuItem_DDE_FilterWeight";
            ToolStripMenuItem_DDE_FilterWeight.Size = new Size(151, 22);
            ToolStripMenuItem_DDE_FilterWeight.Text = "Вес";
            ToolStripMenuItem_DDE_FilterWeight.Click += весToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_FilterDuration
            // 
            ToolStripMenuItem_DDE_FilterDuration.Name = "ToolStripMenuItem_DDE_FilterDuration";
            ToolStripMenuItem_DDE_FilterDuration.Size = new Size(151, 22);
            ToolStripMenuItem_DDE_FilterDuration.Text = "Длительность";
            ToolStripMenuItem_DDE_FilterDuration.Click += длительностьToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_FilterFormat
            // 
            ToolStripMenuItem_DDE_FilterFormat.Name = "ToolStripMenuItem_DDE_FilterFormat";
            ToolStripMenuItem_DDE_FilterFormat.Size = new Size(151, 22);
            ToolStripMenuItem_DDE_FilterFormat.Text = "Формат";
            ToolStripMenuItem_DDE_FilterFormat.Click += форматToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_FilterCategory
            // 
            ToolStripMenuItem_DDE_FilterCategory.Name = "ToolStripMenuItem_DDE_FilterCategory";
            ToolStripMenuItem_DDE_FilterCategory.Size = new Size(151, 22);
            ToolStripMenuItem_DDE_FilterCategory.Text = "Категория";
            ToolStripMenuItem_DDE_FilterCategory.Click += категорияToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_DDE_FilterID
            // 
            ToolStripMenuItem_DDE_FilterID.Name = "ToolStripMenuItem_DDE_FilterID";
            ToolStripMenuItem_DDE_FilterID.Size = new Size(151, 22);
            ToolStripMenuItem_DDE_FilterID.Text = "ID";
            ToolStripMenuItem_DDE_FilterID.Click += iDToolStripMenuItem_Click;
            // 
            // panelMiddle_DDE
            // 
            panelMiddle_DDE.BackColor = Color.FromArgb(20, 20, 20);
            panelMiddle_DDE.BorderStyle = BorderStyle.Fixed3D;
            panelMiddle_DDE.Controls.Add(groupBoxBase_DDE);
            panelMiddle_DDE.Dock = DockStyle.Fill;
            panelMiddle_DDE.Location = new Point(0, 97);
            panelMiddle_DDE.Margin = new Padding(4, 3, 4, 3);
            panelMiddle_DDE.Name = "panelMiddle_DDE";
            panelMiddle_DDE.Size = new Size(938, 378);
            panelMiddle_DDE.TabIndex = 2;
            // 
            // groupBoxBase_DDE
            // 
            groupBoxBase_DDE.Controls.Add(dataGridViewBase_DDE);
            groupBoxBase_DDE.Dock = DockStyle.Fill;
            groupBoxBase_DDE.FlatStyle = FlatStyle.Popup;
            groupBoxBase_DDE.ForeColor = SystemColors.ButtonHighlight;
            groupBoxBase_DDE.Location = new Point(0, 0);
            groupBoxBase_DDE.Margin = new Padding(4, 3, 4, 3);
            groupBoxBase_DDE.Name = "groupBoxBase_DDE";
            groupBoxBase_DDE.Padding = new Padding(4, 3, 4, 3);
            groupBoxBase_DDE.Size = new Size(934, 374);
            groupBoxBase_DDE.TabIndex = 0;
            groupBoxBase_DDE.TabStop = false;
            groupBoxBase_DDE.Text = "Данные";
            // 
            // dataGridViewBase_DDE
            // 
            dataGridViewBase_DDE.BackgroundColor = Color.DimGray;
            dataGridViewBase_DDE.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewBase_DDE.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewBase_DDE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewBase_DDE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBase_DDE.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewBase_DDE.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewBase_DDE.Dock = DockStyle.Fill;
            dataGridViewBase_DDE.GridColor = Color.Gray;
            dataGridViewBase_DDE.Location = new Point(4, 19);
            dataGridViewBase_DDE.Margin = new Padding(4, 3, 4, 3);
            dataGridViewBase_DDE.Name = "dataGridViewBase_DDE";
            dataGridViewBase_DDE.RowHeadersVisible = false;
            dataGridViewBase_DDE.Size = new Size(926, 352);
            dataGridViewBase_DDE.TabIndex = 0;
            dataGridViewBase_DDE.CellContentClick += dataGridViewBase_DDE_CellContentClick;
            // 
            // toolTipButtons_DDE
            // 
            toolTipButtons_DDE.ToolTipIcon = ToolTipIcon.Info;
            toolTipButtons_DDE.ToolTipTitle = "Подсказка";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(938, 532);
            Controls.Add(panelMiddle_DDE);
            Controls.Add(panelDown_DDE);
            Controls.Add(panelUpper_DDE);
            MainMenuStrip = menuStripMain_DDE;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог видеоклипов";
            WindowState = FormWindowState.Maximized;
            panelUpper_DDE.ResumeLayout(false);
            panelUpper_DDE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSort_DDE).EndInit();
            menuStripSort_DDE.ResumeLayout(false);
            menuStripSort_DDE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAbout_DDE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSave_DDE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxManagement_DDE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoad_DDE).EndInit();
            panelDown_DDE.ResumeLayout(false);
            panelDown_DDE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch_DDE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFilter_DDE).EndInit();
            menuStripMain_DDE.ResumeLayout(false);
            menuStripMain_DDE.PerformLayout();
            panelMiddle_DDE.ResumeLayout(false);
            groupBoxBase_DDE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBase_DDE).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialogMain_DDE;
        private System.Windows.Forms.Panel panelUpper_DDE;
        private System.Windows.Forms.PictureBox pictureBoxLoad_DDE;
        private System.Windows.Forms.Button buttonSave_DDE;
        private System.Windows.Forms.Button buttonLoad_DDE;
        private System.Windows.Forms.Panel panelDown_DDE;
        private System.Windows.Forms.Panel panelMiddle_DDE;
        private System.Windows.Forms.PictureBox pictureBoxSave_DDE;
        private System.Windows.Forms.PictureBox pictureBoxAbout_DDE;
        private System.Windows.Forms.PictureBox pictureBoxManagement_DDE;
        private System.Windows.Forms.Button buttonAbout_DDE;
        private System.Windows.Forms.Button buttonManagement_DDE;
        private System.Windows.Forms.PictureBox pictureBoxFilter_DDE;
        private System.Windows.Forms.GroupBox groupBoxBase_DDE;
        private System.Windows.Forms.DataGridView dataGridViewBase_DDE;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMain_DDE;
        private System.Windows.Forms.Button buttonSearch_DDE;
        private System.Windows.Forms.PictureBox pictureBoxSearch_DDE;
        private System.Windows.Forms.MenuStrip menuStripSort_DDE;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMain_DDE;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_SortDuration;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_ColumnWeight;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_ColumnID;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_ColumnDuration_Dec;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_ColumnWeight_Dec;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_ColumnID_Dec;
        private System.Windows.Forms.Button buttonReset_DDE;
        private System.Windows.Forms.PictureBox pictureBoxSort_DDE;
        private System.Windows.Forms.TextBox textBoxSearch_DDE;
        private System.Windows.Forms.TextBox textBoxFilter_DDE;
        private System.Windows.Forms.ToolTip toolTipButtons_DDE;
        private System.Windows.Forms.Button buttonGraph_DDE;
        private System.Windows.Forms.MenuStrip menuStripMain_DDE;
        private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_FilterName;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_FilterWeight;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_FilterDuration;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_FilterFormat;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_FilterCategory;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DDE_FilterID;
        private System.Windows.Forms.Button buttonMenu_DDE;
        private System.Windows.Forms.Button buttonCloseCustom;
        private System.Windows.Forms.Button buttonMinimize_DDE;
        private System.Windows.Forms.Button buttonTheme_DDE;
    }
}

