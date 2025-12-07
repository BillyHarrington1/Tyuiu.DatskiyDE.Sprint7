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

        public string[,] SortUbyv(string[,] basa, int column)
        {
            int[] door = new int[basa.GetLength(0) - 1];
            door[door.Length - 1] = Convert.ToInt32(basa[basa.GetLength(0) - 1, column]);
            for (int i = 0; i < door.Length - 1; i++)
            {
                door[i] = Convert.ToInt32(basa[i + 1, column]);
            }

            Array.Sort(door, (x, y) => y.CompareTo(x));

            string[,] SortedBasa = new string[basa.GetLength(0), basa.GetLength(1)];

            for (int i = 0; i < SortedBasa.GetLength(1); i++)
            {
                SortedBasa[0, i] = basa[0, i];
            }

            for (int i = 0; i < SortedBasa.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < basa.GetLength(0); j++)
                {
                    if (door[i] == Convert.ToInt32(basa[j, column]))
                    {
                        for (int c = 0; c < SortedBasa.GetLength(1); c++)
                        {
                            SortedBasa[i + 1, c] = basa[j, c];
                        }
                        basa[j, column] = "-1";
                        break;
                    }
                }
            }
            return SortedBasa;
        }


        public string[,] SortVozr(string[,] basa, int column)
        {
            int[] input = new int[basa.GetLength(0) - 1];
            input[input.Length - 1] = Convert.ToInt32(basa[basa.GetLength(0) - 1, column]);
            for (int i = 0; i < input.Length - 1; i++)
            {
                input[i] = Convert.ToInt32(basa[i + 1, column]);
            }
            Array.Sort(input, (x, y) => x.CompareTo(y));
            string[,] sortedmx = new string[basa.GetLength(0), basa.GetLength(1)];

            for (int i = 0; i < sortedmx.GetLength(1); i++)
            {
                sortedmx[0, i] = basa[0, i];
            }

            for (int i = 0; i < sortedmx.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < basa.GetLength(0); j++)
                {
                    if (input[i] == Convert.ToInt32(basa[j, column]))
                    {
                        for (int c = 0; c < sortedmx.GetLength(1); c++)
                        {
                            sortedmx[i + 1, c] = basa[j, c];
                        }
                        basa[j, column] = "-1";
                        break;
                    }
                }
            }
            return sortedmx;
        }
    }
}
