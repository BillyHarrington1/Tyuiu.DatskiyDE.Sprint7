using AppVideoClips.Lib;
using LiveCharts;
using LiveCharts.Wpf; // for ColumnSeries


namespace AppVideoClips
{
    public partial class StatsForm_DDE : Form
    {
        public StatsForm_DDE()
        {
            InitializeComponent();
            LoadChart();
        }

        private void LoadChart()
        {
            var groups = DataService.Catalog
                .Items
                .GroupBy(x => x.Theme)
                .ToArray();

            var series = new SeriesCollection();

            foreach (var g in groups)
            {
                series.Add(new ColumnSeries
                {
                    Title = g.Key,
                    Values = new ChartValues<int> { g.Count() }
                });
            }

            cartesianChart_DDE.Series = series;
        }
    }
}
