using LiveCharts.WinForms;
using LiveChartsCore.SkiaSharpView;

namespace AppVideoClips
{
    partial class FormGraph
    {
        private CartesianChart cartesianChart_DDE;

        private void InitializeComponent()
        {
            cartesianChart_DDE = new CartesianChart();
            SuspendLayout();

            cartesianChart_DDE.Dock = System.Windows.Forms.DockStyle.Fill;

            Controls.Add(cartesianChart_DDE);

            Text = "Статистика";
            Width = 800;
            Height = 600;
            ResumeLayout(false);
        }
    }
}
