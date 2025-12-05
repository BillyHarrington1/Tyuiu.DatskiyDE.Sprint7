// AppVideoClips/MainProgramm_DDE.Designer.cs
using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace AppVideoClips
{
    partial class MainProgramm_DDE
    {
        private System.ComponentModel.IContainer components = null;

        private ToolStrip toolStripMain_DDE;
        private ToolStripButton buttonLoad_DDE;
        private ToolStripButton buttonSave_DDE;
        private ToolStripButton buttonAdd_DDE;
        private ToolStripButton buttonDelete_DDE;
        private ToolStripButton buttonCharts_DDE;
        private ToolStripButton buttonAbout_DDE;
        private ToolStripButton buttonExport_DDE;

        private Panel panelTop_DDE;
        private TextBox textBoxSearch_DDE;
        private Button buttonSearch_DDE;

        private FlowLayoutPanel flowLayoutPanelTiles_DDE;
        private StatusStrip statusStrip_DDE;
        private ToolStripStatusLabel labelStatus_DDE;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ToolStrip
            toolStripMain_DDE = new ToolStrip();
            buttonLoad_DDE = new ToolStripButton();
            buttonSave_DDE = new ToolStripButton();
            buttonAdd_DDE = new ToolStripButton();
            buttonDelete_DDE = new ToolStripButton();
            buttonCharts_DDE = new ToolStripButton();
            buttonExport_DDE = new ToolStripButton();
            buttonAbout_DDE = new ToolStripButton();

            toolStripMain_DDE.Items.AddRange(new ToolStripItem[] {
                buttonLoad_DDE, buttonSave_DDE, new ToolStripSeparator(),
                buttonAdd_DDE, buttonDelete_DDE, new ToolStripSeparator(),
                buttonCharts_DDE, buttonExport_DDE, new ToolStripSeparator(),
                buttonAbout_DDE
            });
            toolStripMain_DDE.Dock = DockStyle.Top;

            // buttonLoad_DDE
            buttonLoad_DDE.Text = "Загрузить";
            buttonLoad_DDE.Name = "buttonLoad_DDE";
            buttonLoad_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonLoad_DDE.Click += new EventHandler(buttonLoad_DDE_Click);

            // buttonSave_DDE
            buttonSave_DDE.Text = "Сохранить";
            buttonSave_DDE.Name = "buttonSave_DDE";
            buttonSave_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonSave_DDE.Click += new EventHandler(buttonSave_DDE_Click);

            // buttonAdd_DDE
            buttonAdd_DDE.Text = "Добавить";
            buttonAdd_DDE.Name = "buttonAdd_DDE";
            buttonAdd_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonAdd_DDE.Click += new EventHandler(buttonAdd_DDE_Click);

            // buttonDelete_DDE
            buttonDelete_DDE.Text = "Удалить";
            buttonDelete_DDE.Name = "buttonDelete_DDE";
            buttonDelete_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonDelete_DDE.Click += new EventHandler(buttonDelete_DDE_Click);

            // buttonCharts_DDE
            buttonCharts_DDE.Text = "Статистика";
            buttonCharts_DDE.Name = "buttonCharts_DDE";
            buttonCharts_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonCharts_DDE.Click += new EventHandler(buttonCharts_DDE_Click);

            // buttonExport_DDE
            buttonExport_DDE.Text = "Экспорт";
            buttonExport_DDE.Name = "buttonExport_DDE";
            buttonExport_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonExport_DDE.Click += new EventHandler(buttonExport_DDE_Click);

            // buttonAbout_DDE
            buttonAbout_DDE.Text = "О программе";
            buttonAbout_DDE.Name = "buttonAbout_DDE";
            buttonAbout_DDE.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonAbout_DDE.Click += new EventHandler(buttonAbout_DDE_Click);

            // Top panel (search)
            panelTop_DDE = new Panel();
            panelTop_DDE.Dock = DockStyle.Top;
            panelTop_DDE.Height = 36;
            panelTop_DDE.Padding = new Padding(6);

            textBoxSearch_DDE = new TextBox();
            textBoxSearch_DDE.Name = "textBoxSearch_DDE";
            textBoxSearch_DDE.Dock = DockStyle.Fill;
            textBoxSearch_DDE.KeyDown += new KeyEventHandler(textBoxSearch_DDE_KeyDown);

            buttonSearch_DDE = new Button();
            buttonSearch_DDE.Name = "buttonSearch_DDE";
            buttonSearch_DDE.Text = "Поиск";
            buttonSearch_DDE.Dock = DockStyle.Right;
            buttonSearch_DDE.Width = 100;
            buttonSearch_DDE.Click += new EventHandler(buttonSearch_DDE_Click);

            panelTop_DDE.Controls.Add(textBoxSearch_DDE);
            panelTop_DDE.Controls.Add(buttonSearch_DDE);

            // FlowLayoutPanel (tiles)
            flowLayoutPanelTiles_DDE = new FlowLayoutPanel();
            flowLayoutPanelTiles_DDE.Name = "flowLayoutPanelTiles_DDE";
            flowLayoutPanelTiles_DDE.Dock = DockStyle.Fill;
            flowLayoutPanelTiles_DDE.AutoScroll = true;
            flowLayoutPanelTiles_DDE.WrapContents = true;
            flowLayoutPanelTiles_DDE.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelTiles_DDE.ControlAdded += new ControlEventHandler(flowLayoutPanelTiles_DDE_ControlAdded);

            // StatusStrip
            statusStrip_DDE = new StatusStrip();
            labelStatus_DDE = new ToolStripStatusLabel();
            labelStatus_DDE.Name = "labelStatus_DDE";
            labelStatus_DDE.Text = "Готово";
            statusStrip_DDE.Items.Add(labelStatus_DDE);
            statusStrip_DDE.Dock = DockStyle.Bottom;

            // Main form
            this.Text = "Каталог видео клипов — YouTube плитки";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1100;
            this.Height = 700;

            this.Controls.Add(flowLayoutPanelTiles_DDE);
            this.Controls.Add(panelTop_DDE);
            this.Controls.Add(toolStripMain_DDE);
            this.Controls.Add(statusStrip_DDE);

            this.Load += new EventHandler(MainProgramm_DDE_Load);

            // добавим небольшие кнопки для отдельных чартов (в правой нижней части)
            // их можно разместить как плавающие кнопки — здесь простая реализация: панель с кнопками
            var panelSmallButtons = new Panel()
            {
                Dock = DockStyle.Right,
                Width = 120,
                Padding = new Padding(6)
            };
            var btnDur = new Button() { Text = "Гистограмма", Name = "buttonChartDuration_DDE", Dock = DockStyle.Top, Height = 36 };
            btnDur.Click += new EventHandler(buttonChartDuration_DDE_Click);
            var btnCost = new Button() { Text = "Диагр. стоимости", Name = "buttonChartCost_DDE", Dock = DockStyle.Top, Height = 36 };
            btnCost.Click += new EventHandler(buttonChartCost_DDE_Click);

            panelSmallButtons.Controls.Add(btnCost);
            panelSmallButtons.Controls.Add(btnDur);

            // Добавим панель справа в форму (но выше остальных) - вставляем её перед добавлением flowLayoutPanelTiles_DDE, поэтому
            // делаем простой перехват: добавим панель в Controls после flowLayoutPanel, затем установим z-order при необходимости.
            this.Controls.Add(panelSmallButtons);
            panelSmallButtons.BringToFront();
        }
    }
}
