using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AppVideoClips
{
    public class FormVideoEditor : Form
    {
        private TextBox txtInput1;
        private TextBox txtInput2;
        private Button btnTrim;
        private Button btnMerge;
        private NumericUpDown numStart;
        private NumericUpDown numDuration;

        public FormVideoEditor()
        {
            this.Text = "Редактор видео";
            this.ClientSize = new Size(500, 220);
            Initialize();
            Theme.ApplyTheme(this);
        }

        private void Initialize()
        {
            txtInput1 = new TextBox { PlaceholderText = "Путь к файлу 1", Width = 420, Location = new Point(10, 10) };
            txtInput2 = new TextBox { PlaceholderText = "Путь к файлу 2 (для склейки)", Width = 420, Location = new Point(10, 40) };
            numStart = new NumericUpDown { Minimum = 0, Maximum = 3600, Location = new Point(10, 80), Width = 100 };
            numDuration = new NumericUpDown { Minimum = 1, Maximum = 3600, Value = 10, Location = new Point(120, 80), Width = 100 };
            btnTrim = new Button { Text = "Обрезать (trim)", Location = new Point(10, 120), Width = 150 };
            btnMerge = new Button { Text = "Склеить (merge)", Location = new Point(170, 120), Width = 150 };

            btnTrim.Click += BtnTrim_Click;
            btnMerge.Click += BtnMerge_Click;

            this.Controls.Add(txtInput1);
            this.Controls.Add(txtInput2);
            this.Controls.Add(numStart);
            this.Controls.Add(numDuration);
            this.Controls.Add(btnTrim);
            this.Controls.Add(btnMerge);
        }

        private void BtnTrim_Click(object sender, EventArgs e)
        {
            var input = txtInput1.Text;
            if (string.IsNullOrWhiteSpace(input) || !File.Exists(input)) { MessageBox.Show("Укажите корректный файл"); return; }
            var start = (double)numStart.Value;
            var dur = (double)numDuration.Value;
            var outp = Path.Combine(Path.GetDirectoryName(input), Path.GetFileNameWithoutExtension(input) + "_trim" + Path.GetExtension(input));

            // ffmpeg 
            var args = $"-y -i \"{input}\" -ss {start} -t {dur} -c copy \"{outp}\"";
            RunProcess("ffmpeg", args);
            MessageBox.Show("Обрезка завершена");
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            var a = txtInput1.Text; var b = txtInput2.Text;
            if (string.IsNullOrWhiteSpace(a) || !File.Exists(a) || string.IsNullOrWhiteSpace(b) || !File.Exists(b)) { MessageBox.Show("Укажите оба файла"); return; }
            var dir = Path.GetDirectoryName(a);
            var listFile = Path.Combine(dir, "merge_list.txt");
            File.WriteAllText(listFile, $"file '{a}'\r\nfile '{b}'\r\n");
            var outp = Path.Combine(dir, "merged" + Path.GetExtension(a));

            var args = $"-y -f concat -safe 0 -i \"{listFile}\" -c copy \"{outp}\"";
            RunProcess("ffmpeg", args);
            MessageBox.Show("Склейка завершена");
        }

        private void RunProcess(string exe, string args)
        {
            try
            {
                var p = new Process();
                p.StartInfo.FileName = exe;
                p.StartInfo.Arguments = args;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Требуется ffmpeg в PATH. Ошибка: " + ex.Message);
            }
        }
    }
}
