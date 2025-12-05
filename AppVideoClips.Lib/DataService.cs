using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AppVideoClips.Lib
{
    // =========================================
    // 🎬 МОДЕЛЬ ВИДЕОКЛИПА
    // =========================================
    public class VideoClip
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public DateTime RecordedDate { get; set; } = DateTime.MinValue;
        public int DurationSeconds { get; set; }
        public string Theme { get; set; } = "";
        public decimal Cost { get; set; }

        public string ActorLastName { get; set; } = "";
        public string ActorFirstName { get; set; } = "";
        public string ActorPatronymic { get; set; } = "";
        public string ActorRole { get; set; } = "";
    }

    // =========================================
    // 📄 CSV СЕРВИС
    // =========================================
    public static class CsvService
    {
        public static IList<VideoClip> ReadFromCsv(string path)
        {
            var list = new List<VideoClip>();
            if (!File.Exists(path)) return list;

            using var sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine(); // Пропуск заголовка

            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                var fields = ParseCsvLine(line);
                if (fields.Count < 10) continue;

                list.Add(new VideoClip
                {
                    Id = int.Parse(fields[0]),
                    Code = fields[1],
                    RecordedDate = DateTime.Parse(fields[2]),
                    DurationSeconds = int.Parse(fields[3]),
                    Theme = fields[4],
                    Cost = decimal.Parse(fields[5], CultureInfo.InvariantCulture),
                    ActorLastName = fields[6],
                    ActorFirstName = fields[7],
                    ActorPatronymic = fields[8],
                    ActorRole = fields[9]
                });
            }

            return list;
        }

        public static void WriteToCsv(string path, IEnumerable<VideoClip> clips)
        {
            using var sw = new StreamWriter(path, false, Encoding.UTF8);

            sw.WriteLine("Id,Code,RecordedDate,DurationSeconds,Theme,Cost,ActorLastName,ActorFirstName,ActorPatronymic,ActorRole");

            foreach (var v in clips)
            {
                sw.WriteLine(
                    $"{v.Id}," +
                    $"{Escape(v.Code)}," +
                    $"{v.RecordedDate:yyyy-MM-dd}," +
                    $"{v.DurationSeconds}," +
                    $"{Escape(v.Theme)}," +
                    $"{v.Cost.ToString(CultureInfo.InvariantCulture)}," +
                    $"{Escape(v.ActorLastName)}," +
                    $"{Escape(v.ActorFirstName)}," +
                    $"{Escape(v.ActorPatronymic)}," +
                    $"{Escape(v.ActorRole)}"
                );
            }
        }

        private static List<string> ParseCsvLine(string line)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;

            foreach (char c in line)
            {
                if (c == '"') inQuotes = !inQuotes;
                else if (c == ',' && !inQuotes)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
                else sb.Append(c);
            }

            result.Add(sb.ToString());
            return result;
        }

        private static string Escape(string value)
        {
            if (value.Contains(",")) return $"\"{value}\"";
            return value;
        }
    }

    // =========================================
    // 📦 КАТАЛОГ ВИДЕОКЛИПОВ + СТАТИСТИКА
    // =========================================
    public class VideoCatalog
    {
        private readonly List<VideoClip> _items = new();

        public IReadOnlyList<VideoClip> Items => _items;

        public void Load(string path)
        {
            _items.Clear();
            _items.AddRange(CsvService.ReadFromCsv(path));
        }

        public void Save(string path)
        {
            CsvService.WriteToCsv(path, _items);
        }

        public void Add(VideoClip clip)
        {
            clip.Id = _items.Any() ? _items.Max(x => x.Id) + 1 : 1;
            _items.Add(clip);
        }

        public void Update(VideoClip clip)
        {
            var old = _items.First(x => x.Id == clip.Id);
            _items.Remove(old);
            _items.Add(clip);
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _items.Remove(item);
        }

        public IEnumerable<VideoClip> Search(string query)
        {
            return _items.Where(x =>
                x.Code.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                x.Theme.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                x.ActorLastName.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        // ===== 📊 СТАТИСТИКА =====
        public int Count() => _items.Count;

        public int TotalDuration() => _items.Sum(x => x.DurationSeconds);

        public decimal SumCost() => _items.Sum(x => x.Cost);

        public decimal AvgCost() =>
            _items.Any() ? _items.Average(x => x.Cost) : 0;

        public decimal MinCost() =>
            _items.Any() ? _items.Min(x => x.Cost) : 0;

        public decimal MaxCost() =>
            _items.Any() ? _items.Max(x => x.Cost) : 0;

        public Dictionary<string, int> DurationHistogram(int step = 60)
        {
            return _items
                .GroupBy(x => (x.DurationSeconds / step) * step)
                .ToDictionary(
                    g => $"{g.Key}-{g.Key + step} сек",
                    g => g.Count());
        }
    }

    // =========================================
    // 🔧 ОБЩИЙ DATA SERVICE
    // =========================================
    public static class DataService
    {
        public static readonly VideoCatalog Catalog = new();

        public static string DefaultCsvPath =>
            Path.Combine(AppContext.BaseDirectory, "videoclips.csv");

        public static void EnsureDefaultFileExists()
        {
            if (!File.Exists(DefaultCsvPath))
            {
                File.WriteAllText(DefaultCsvPath,
                    "Id,Code,RecordedDate,DurationSeconds,Theme,Cost,ActorLastName,ActorFirstName,ActorPatronymic,ActorRole\n");
            }
        }
    }
}
