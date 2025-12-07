using AppVideoClips.Lib;
using System.Text;
namespace AppVideoClips
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FormMenu formmenu = new FormMenu();
            formmenu.TopMost = true;
            formmenu.Show();

            // Improve DataGridView contrast for readability
            try
            {
                dataGridViewBase_GAM.EnableHeadersVisualStyles = false;
                dataGridViewBase_GAM.BackgroundColor = Color.White;
                dataGridViewBase_GAM.GridColor = Color.LightGray;

                dataGridViewBase_GAM.DefaultCellStyle.BackColor = Color.White;
                dataGridViewBase_GAM.DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewBase_GAM.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                dataGridViewBase_GAM.DefaultCellStyle.SelectionForeColor = Color.White;

                dataGridViewBase_GAM.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                dataGridViewBase_GAM.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

                dataGridViewBase_GAM.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                dataGridViewBase_GAM.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                dataGridViewBase_GAM.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                dataGridViewBase_GAM.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
            catch
            {
                // ignore if designer control not yet created in some contexts
            }


        }

        DataService ds = new DataService();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DataSet.csv");
        //string path = @"C:\Users\djura\Desktop\DataSet.csv";
        static string openFile = string.Empty;
        static int rows = 0;
        static int columns = 0;
        static string[,] matrix = new string[0, 0];
        private void buttonLoad_GAM_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialogMain_GAM.ShowDialog();
                openFile = openFileDialogMain_GAM.FileName;

                matrix = ds.LoadDataSet(openFile);
                rows = matrix.GetLength(0);
                columns = matrix.GetLength(1);
                dataGridViewBase_GAM.RowCount = rows + 1;
                dataGridViewBase_GAM.ColumnCount = columns;


                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewBase_GAM.Rows[i].Cells[j].Value = matrix[i, j];
                        dataGridViewBase_GAM.Rows[i].Cells[j].Selected = false;
                    }
                }

                dataGridViewBase_GAM.Columns[0].Width = 100;
                dataGridViewBase_GAM.Columns[1].Width = 150;
                dataGridViewBase_GAM.Columns[3].Width = 150;
                dataGridViewBase_GAM.Columns[6].Width = 900;
                buttonReset_GAM.Enabled = true;

            }
            catch
            {
                MessageBox.Show("Âîçíèêëà ïðîáëåìà ñ îòêðûòèåì ôàéëà", "Îøèáêà!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_GAM_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogMain_GAM.FileName = "OutPutFileTask7.csv";
                saveFileDialogMain_GAM.InitialDirectory = Directory.GetCurrentDirectory();

                if (saveFileDialogMain_GAM.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialogMain_GAM.FileName;

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    int rows = dataGridViewBase_GAM.RowCount;
                    int columns = dataGridViewBase_GAM.ColumnCount;

                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewBase_GAM.Rows[i].Cells[j].Value);

                            if (j != columns - 1)
                            {
                                strBuilder.Append(";");
                            }
                        }

                        strBuilder.AppendLine();
                    }

                    File.WriteAllText(path, strBuilder.ToString(), Encoding.UTF8);

                    MessageBox.Show("Ôàéë óñïåøíî ñîõðàíåí", "Óñïåõ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Íå óäàëîñü ñîõðàíèòü ôàéë. Îøèáêà: {ex.Message}", "Îøèáêà!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAbout_GAM_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonSearch_GAM_Click(object sender, EventArgs e)
        {
            dataGridViewBase_GAM.ClearSelection();
            if (textBoxSearch_DDE.Text == "")
            {
                MessageBox.Show("Ââåäèòå êðèòåðèé äëÿ ïîèñêà", "Ïðåäóïðåæäåíèå", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (matrix[i, j].ToLower().Contains(textBoxSearch_DDE.Text.ToLower()))
                        {
                            dataGridViewBase_GAM.Rows[i].Selected = true;
                        }
                    }
                }
            }


        }



        private void ñîðòèðîâêàToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortVozr(mx, 2);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }

        private void ñòîëáåöÂåñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortVozr(mx, 5);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }


        private void ñòîëáåöIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortVozr(mx, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }


        private void buttonReset_GAM_Click(object sender, EventArgs e)
        {
            for (int v = 0; v < rows; v++)
            {
                dataGridViewBase_GAM.Rows[v].Visible = true;
            }

            dataGridViewBase_GAM.Rows.Clear();
            matrix = ds.LoadDataSet(path);
            rows = matrix.GetLength(0);
            columns = matrix.GetLength(1);
            dataGridViewBase_GAM.RowCount = rows + 1;
            dataGridViewBase_GAM.ColumnCount = columns;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = matrix[i, j];
                    dataGridViewBase_GAM.Rows[i].Cells[j].Selected = false;
                }
            }
            dataGridViewBase_GAM.Columns[0].Width = 100;
            dataGridViewBase_GAM.Columns[1].Width = 150;
            dataGridViewBase_GAM.Columns[3].Width = 150;
        }

        private void ñòîëáåöÄëèòåëüíîñòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortUbyv(mx, 2);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }

        private void ñòîëáåöÂåñToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortUbyv(mx, 5);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }

        private void ñòîëáåöÄàòàToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortUbyv(mx, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_GAM.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }



        private void buttonRight_GAM_Click(object sender, EventArgs e)
        {
            dataGridViewBase_GAM.HorizontalScrollingOffset = dataGridViewBase_GAM.HorizontalScrollingOffset + 10;
        }

        private void buttonLeft_GAM_Click(object sender, EventArgs e)
        {
            if (dataGridViewBase_GAM.HorizontalScrollingOffset >= 10)
            {
                dataGridViewBase_GAM.HorizontalScrollingOffset = dataGridViewBase_GAM.HorizontalScrollingOffset - 10;
            }
            else
            {
                dataGridViewBase_GAM.HorizontalScrollingOffset = 0;
            }

        }

        private void buttonFilter_GAM_Click(object sender, EventArgs e)
        {
            if (textBoxFilter_DDE.Text == "")
            {
                MessageBox.Show("Ââåäèòå êðèòåðèé äëÿ ôèëüòðàöèè", "Ïðåäóïðåæäåíèå", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string filterValue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < dataGridViewBase_GAM.Rows.Count; i++)
                {
                    if (!dataGridViewBase_GAM.Rows[i].IsNewRow)
                    {
                        bool rowShouldBeVisible = false;

                        for (int j = 0; j < dataGridViewBase_GAM.Columns.Count; j++)
                        {
                            var cellValue = dataGridViewBase_GAM.Rows[i].Cells[j].Value?.ToString()?.ToLower();

                            if (cellValue != null && cellValue.IndexOf(filterValue, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                rowShouldBeVisible = true;
                                break;
                            }
                        }
                        for (int q = 0; q < columns; q++)
                        {
                            dataGridViewBase_GAM.Rows[matrix.GetLength(0) - 1].Cells[q].Value = "";

                        }

                        dataGridViewBase_GAM.Rows[i].Visible = rowShouldBeVisible;

                    }
                }
            }
            //string filtervalue = textBoxFilter_GAM.Text.ToLower();
            //for (int i = 1; i < rows; i++)
            //{
            //    if (!(matrix[i, 1].ToLower().Contains(filtervalue)))
            //    {
            //        dataGridViewBase_GAM.Rows[i].Visible = false;
            //    }

            //}


        }

        private void buttonManagement_GAM_Click(object sender, EventArgs e)
        {
            FormManual formmanual = new FormManual();
            formmanual.ShowDialog();
        }

        private void buttonLoad_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonLoad_DDE.BackColor = Color.DarkTurquoise;
            buttonLoad_DDE.ForeColor = Color.Black;
        }



        private void buttonSave_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonSave_DDE.BackColor = Color.DarkTurquoise;
            buttonSave_DDE.ForeColor = Color.Black;
        }

        private void buttonSave_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonSave_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonSave_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonLoad_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonLoad_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonLoad_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonManagement_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonManagement_DDE.BackColor = Color.DarkTurquoise;
            buttonManagement_DDE.ForeColor = Color.Black;
        }

        private void buttonManagement_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonManagement_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonManagement_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonAbout_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonAbout_DDE.BackColor = Color.DarkTurquoise;
            buttonAbout_DDE.ForeColor = Color.Black;
        }

        private void buttonAbout_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonAbout_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonAbout_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonSearch_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonSearch_DDE.BackColor = Color.DarkTurquoise;
            buttonSearch_DDE.ForeColor = Color.Black;
        }

        private void buttonSearch_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonSearch_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonSearch_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonReset_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonReset_GAM.BackColor = Color.DarkTurquoise;

        }

        private void buttonReset_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonReset_GAM.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void buttonLeft_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonLeft_GAM.BackColor = Color.LightGray;
        }

        private void buttonLeft_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonLeft_GAM.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void buttonRight_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonRight_GAM.BackColor = Color.LightGray;
        }

        private void buttonRight_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonRight_GAM.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void buttonGraph_GAM_Click(object sender, EventArgs e)
        {
            FormGraph fg = new FormGraph();

            fg.Show();


        }

        private void íàçâàíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filtervalue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < rows; i++)
                {
                    if (!(matrix[i, 1].ToLower().Contains(filtervalue)))
                    {
                        dataGridViewBase_GAM.Rows[i].Visible = false;
                        //dataGridViewBase_GAM.Rows.RemoveAt(i);

                    }


                }
                //dataGridViewBase_GAM.Rows.RemoveAt(rows);
                dataGridViewBase_GAM.Rows[rows].Visible = false;

            }
            catch
            {

            }
        }

        private void âåñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filtervalue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < rows; i++)
                {
                    if (!(matrix[i, 5].ToLower().Contains(filtervalue)))
                    {
                        dataGridViewBase_GAM.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_GAM.Rows[rows].Visible = false;
            }
            catch
            {

            }
        }

        private void äëèòåëüíîñòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filtervalue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < rows; i++)
                {
                    if (!(matrix[i, 2].ToLower().Contains(filtervalue)))
                    {
                        dataGridViewBase_GAM.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_GAM.Rows[rows].Visible = false;
            }
            catch
            {

            }
        }

        private void ôîðìàòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filtervalue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < rows; i++)
                {
                    if (!(matrix[i, 3].ToLower().Contains(filtervalue)))
                    {
                        dataGridViewBase_GAM.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_GAM.Rows[rows].Visible = false;
            }
            catch
            {

            }
        }

        private void êàòåãîðèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filtervalue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < rows; i++)
                {
                    if (!(matrix[i, 6].ToLower().Contains(filtervalue)))
                    {
                        dataGridViewBase_GAM.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_GAM.Rows[rows].Visible = false;
            }
            catch
            {

            }
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filtervalue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < rows; i++)
                {
                    if (!(matrix[i, 0].ToLower().Contains(filtervalue)))
                    {
                        dataGridViewBase_GAM.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_GAM.Rows[rows].Visible = false;

            }
            catch
            {

            }
        }

        private void buttonGraph_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonGraph_DDE.BackColor = Color.DarkTurquoise;
            buttonGraph_DDE.ForeColor = Color.Black;
        }

        private void buttonGraph_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonGraph_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonGraph_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonMenu_GAM_Click(object sender, EventArgs e)
        {
            FormMenu fmen = new FormMenu();

            fmen.TopMost = true;
            fmen.ShowDialog();
        }

        private void buttonMenu_GAM_MouseEnter(object sender, EventArgs e)
        {
            buttonMenu_DDE.BackColor = Color.DarkTurquoise;
            buttonMenu_DDE.ForeColor = Color.Black;
        }

        private void buttonMenu_GAM_MouseLeave(object sender, EventArgs e)
        {
            buttonMenu_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonMenu_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void dataGridViewBase_GAM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}