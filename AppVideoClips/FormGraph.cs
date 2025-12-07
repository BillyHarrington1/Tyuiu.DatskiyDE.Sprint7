using AppVideoClips.Lib;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Drawing;

namespace AppVideoClips
{
    public partial class FormGraph : Form
    {
        private string[] headers = Array.Empty<string>();
        private string csvPathGlobal = string.Empty;

        public FormGraph()
        {
            InitializeComponent();
            InitializeFromCsv();
        }

        private void InitializeFromCsv()
        {
            try
            {
                DataService ds = new DataService();
                string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DataSet.csv");
                string csvPath = File.Exists(defaultPath) ? defaultPath : null;

                var main = Application.OpenForms.OfType<FormMain>().FirstOrDefault();
                if (main != null)
                {
                    var fi = main.GetType().GetField("openFile", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                    if (fi != null)
                    {
                        var val = fi.GetValue(null) as string;
                        if (!string.IsNullOrWhiteSpace(val) && File.Exists(val)) csvPath = val;
                    }
                }

                if (string.IsNullOrWhiteSpace(csvPath) || !File.Exists(csvPath))
                {
                    MessageBox.Show("CSV файл не найден. Разместите DataSet.csv на рабочем столе или откройте файл в главном окне.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                csvPathGlobal = csvPath;
                var matrix = ds.LoadDataSet(csvPath);
                if (matrix == null || matrix.GetLength(0) == 0) return;

                int cols = matrix.GetLength(1);
                headers = new string[cols];
                for (int c = 0; c < cols; c++) headers[c] = matrix[0, c];

                comboBoxColumn_DDE.Items.Clear();
                comboBoxColumn_DDE.Items.AddRange(headers);
                if (comboBoxColumn_DDE.Items.Count > 0) comboBoxColumn_DDE.SelectedIndex = 0;


                comboBoxOperation_DDE.Items.Clear();
                comboBoxOperation_DDE.Items.AddRange(new string[] { "Количество (уникальные)", "Сумма", "Среднее", "Сортировка по убыванию", "Сортировка по возрастанию" });
                comboBoxOperation_DDE.SelectedIndex = 0;


                listBoxIdName_DDE.Items.Clear();
                int rows = matrix.GetLength(0);
                int idCol = 0;
                int nameCol = -1;
                for (int c = 0; c < headers.Length; c++)
                {
                    var h = (headers[c] ?? "").ToLower();
                    if (h.Contains("имя")) nameCol = c;
                    if (h.Contains("фам")) nameCol = c;
                }
                if (nameCol == -1) nameCol = Math.Min(2, headers.Length - 1);

                for (int r = 1; r < rows; r++)
                {
                    var id = matrix[r, idCol] ?? string.Empty;
                    var name = matrix[r, nameCol] ?? string.Empty;
                    listBoxIdName_DDE.Items.Add($"{id} -> {name}");
                }


                PlotSelectedColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации графика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxColumn_DDE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonApply_DDE_Click(object sender, EventArgs e)
        {
            PlotSelectedColumn();
        }

        private void listBoxIdName_DDE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PlotSelectedColumn()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(csvPathGlobal)) return;
                if (comboBoxColumn_DDE.SelectedIndex < 0) return;
                if (comboBoxOperation_DDE.SelectedIndex < 0) comboBoxOperation_DDE.SelectedIndex = 0;

                DataService ds = new DataService();
                var matrix = ds.LoadDataSet(csvPathGlobal);
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                int col = comboBoxColumn_DDE.SelectedIndex;
                string op = comboBoxOperation_DDE.SelectedItem.ToString();

                bool isNumeric = true;
                for (int r = 1; r < rows; r++)
                {
                    if (!double.TryParse(matrix[r, col]?.Replace(',', '.'), out _))
                    {
                        isNumeric = false;
                        break;
                    }
                }

                cartesianChart_DDE.Series.Clear();
                cartesianChart_DDE.AxisX.Clear();
                cartesianChart_DDE.AxisY.Clear();

                if (isNumeric && (op == "Сумма" || op == "Среднее"))
                {

                    var values = new List<double>();
                    var labels = new List<string>();
                    for (int r = 1; r < rows; r++)
                    {
                        if (double.TryParse(matrix[r, col]?.Replace(',', '.'), out var v)) values.Add(v);
                        else values.Add(0);
                        labels.Add(matrix[r, 0]);
                    }

                    double resultVal = 0;
                    if (op == "Сумма") resultVal = values.Sum();
                    else if (op == "Среднее") resultVal = values.Count > 0 ? values.Average() : 0;

                    cartesianChart_DDE.Series = new SeriesCollection
                    {
                        new ColumnSeries { Title = op + " of " + headers[col], Values = new ChartValues<double> { resultVal }, Fill = System.Windows.Media.Brushes.MediumSeaGreen }
                    };
                    cartesianChart_DDE.AxisX.Add(new Axis { Labels = new List<string> { op } });
                    cartesianChart_DDE.AxisY.Add(new Axis { Title = op, LabelFormatter = value => value.ToString("N0"), MinValue = 0 });
                }
                else if (op == "Количество (уникальные)")
                {
                    var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                    for (int r = 1; r < rows; r++)
                    {
                        var key = matrix[r, col] ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(key)) key = "(empty)";
                        if (!counts.ContainsKey(key)) counts[key] = 0;
                        counts[key]++;
                    }

                    var labels = counts.Keys.ToArray();
                    var values = counts.Values.Select(v => (double)v).ToArray();
                    cartesianChart_DDE.Series = new SeriesCollection
                    {
                        new ColumnSeries { Title = headers[col], Values = new ChartValues<double>(values), Fill = System.Windows.Media.Brushes.CornflowerBlue }
                    };
                    cartesianChart_DDE.AxisX.Add(new Axis { Labels = labels.ToList(), LabelsRotation = 30, Separator = new Separator { Step = 1 } });
                    cartesianChart_DDE.AxisY.Add(new Axis { Title = "Count", LabelFormatter = value => value.ToString("N0"), MinValue = 0 });
                }
                else if (op == "Сортировка по убыванию" || op == "Сортировка по возрастанию")
                {

                    var list = new List<(string label, double value)>();
                    for (int r = 1; r < rows; r++)
                    {
                        double v = 0;
                        if (double.TryParse(matrix[r, col]?.Replace(',', '.'), out var parsed)) v = parsed;
                        list.Add((matrix[r, 0], v));
                    }
                    if (op == "Сортировка по убыванию") list = list.OrderByDescending(x => x.value).ToList(); else list = list.OrderBy(x => x.value).ToList();
                    int take = Math.Min(20, list.Count);
                    var labels = list.Take(take).Select(x => x.label).ToList();
                    var values = list.Take(take).Select(x => x.value).ToArray();

                    cartesianChart_DDE.Series = new SeriesCollection
                    {
                        new ColumnSeries { Title = headers[col], Values = new ChartValues<double>(values), Fill = System.Windows.Media.Brushes.Orange }
                    };
                    cartesianChart_DDE.AxisX.Add(new Axis { Labels = labels, LabelsRotation = 45, Separator = new Separator { Step = 1 } });
                    cartesianChart_DDE.AxisY.Add(new Axis { Title = headers[col], LabelFormatter = value => value.ToString("N0"), MinValue = 0 });
                }
                else
                {

                    var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                    for (int r = 1; r < rows; r++)
                    {
                        var key = matrix[r, col] ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(key)) key = "(empty)";
                        if (!counts.ContainsKey(key)) counts[key] = 0;
                        counts[key]++;
                    }

                    var labels = counts.Keys.ToArray();
                    var values = counts.Values.Select(v => (double)v).ToArray();
                    cartesianChart_DDE.Series = new SeriesCollection
                    {
                        new ColumnSeries { Title = headers[col], Values = new ChartValues<double>(values), Fill = System.Windows.Media.Brushes.CornflowerBlue }
                    };
                    cartesianChart_DDE.AxisX.Add(new Axis { Labels = labels.ToList(), LabelsRotation = 30, Separator = new Separator { Step = 1 } });
                    cartesianChart_DDE.AxisY.Add(new Axis { Title = "Count", LabelFormatter = value => value.ToString("N0"), MinValue = 0 });
                }

                cartesianChart_DDE.LegendLocation = LegendLocation.Top;
                cartesianChart_DDE.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось построить график: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormGraph_Load(object sender, EventArgs e)
        {

        }

        private void cartesianChart_DDE_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
