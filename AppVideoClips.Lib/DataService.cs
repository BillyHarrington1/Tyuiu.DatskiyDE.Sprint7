using System.Globalization;
using System.Text;
namespace AppVideoClips.Lib
{
    public class DataService
    {

        public string[,] LoadDataSet(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string[] lines;
            try
            {
                lines = File.ReadAllLines(path, Encoding.GetEncoding(1251));
            }
            catch
            {
                lines = File.ReadAllLines(path, Encoding.UTF8);
            }

            var nonEmpty = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
            if (nonEmpty.Length == 0)
                return new string[0, 0];

            char sep = nonEmpty[0].Contains(';') ? ';' : ',';

            int columns = nonEmpty.Max(l => SplitCsvLine(l, sep).Length);
            int rows = nonEmpty.Length;
            string[,] basa = new string[rows, columns];

            for (int i = 0; i < nonEmpty.Length; i++)
            {
                var parts = SplitCsvLine(nonEmpty[i], sep);
                for (int j = 0; j < columns; j++)
                {
                    if (j < parts.Length)
                    {          
                        var v = parts[j].Trim();
                        if (v.Length >= 2 && v.StartsWith("\"") && v.EndsWith("\""))
                            v = v.Substring(1, v.Length - 2);
                        basa[i, j] = v;
                    }
                    else
                    {
                        basa[i, j] = string.Empty;
                    }
                }
            }

            return basa;
        }

        private static string[] SplitCsvLine(string line, char separator)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    sb.Append(c);
                    continue;
                }

                if (c == separator && !inQuotes)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }

            result.Add(sb.ToString());
            return result.ToArray();
        }

        // try parse numeric or timespan-like values to double for sorting
        private static double ParseSortableValue(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return double.NaN;
            s = s.Trim();

            // Try TimeSpan parse (e.g., 0:02:30 or 00:02:30)
            if (TimeSpan.TryParse(s, out var ts)) return ts.TotalSeconds;

            // Normalize decimal separators then try double
            var normalized = s.Replace(',', '.');
            if (double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var d)) return d;

            // Extract digits and dots if mixed with text (e.g., "750 KB")
            var digits = new string(s.Where(ch => char.IsDigit(ch) || ch == '.' || ch == ',').ToArray()).Replace(',', '.');
            if (!string.IsNullOrEmpty(digits) && double.TryParse(digits, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;

            return double.NaN;
        }

        public string[,] SortUbyv(string[,] basa, int column)
        {
            // descending
            int rows = basa.GetLength(0);
            int cols = basa.GetLength(1);
            if (rows <= 1) return basa;

            var header = new string[cols];
            for (int c = 0; c < cols; c++) header[c] = basa[0, c];

            var list = new List<(int rowIndex, double value)>();
            for (int r = 1; r < rows; r++)
            {
                var raw = basa[r, column] ?? string.Empty;
                var val = ParseSortableValue(raw);
                list.Add((r, val));
            }

            var sorted = list.OrderByDescending(x => double.IsNaN(x.value) ? double.NegativeInfinity : x.value).ToList();

            var result = new string[rows, cols];
            for (int c = 0; c < cols; c++) result[0, c] = header[c];
            for (int i = 0; i < sorted.Count; i++)
            {
                int src = sorted[i].rowIndex;
                for (int c = 0; c < cols; c++) result[i + 1, c] = basa[src, c];
            }

            return result;
        }

        public string[,] SortVozr(string[,] basa, int column)
        {
            // ascending
            int rows = basa.GetLength(0);
            int cols = basa.GetLength(1);
            if (rows <= 1) return basa;

            var header = new string[cols];
            for (int c = 0; c < cols; c++) header[c] = basa[0, c];

            var list = new List<(int rowIndex, double value)>();
            for (int r = 1; r < rows; r++)
            {
                var raw = basa[r, column] ?? string.Empty;
                var val = ParseSortableValue(raw);
                list.Add((r, val));
            }

            var sorted = list.OrderBy(x => double.IsNaN(x.value) ? double.PositiveInfinity : x.value).ToList();

            var result = new string[rows, cols];
            for (int c = 0; c < cols; c++) result[0, c] = header[c];
            for (int i = 0; i < sorted.Count; i++)
            {
                int src = sorted[i].rowIndex;
                for (int c = 0; c < cols; c++) result[i + 1, c] = basa[src, c];
            }

            return result;
        }
    }
}
