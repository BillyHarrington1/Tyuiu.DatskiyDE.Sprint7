using AppVideoClips.Lib;
using System.Text;
namespace AppVideoClips
{
    public partial class FormMain : Form
    {
        // single close button field
        private Button buttonCloseCustom;
        private bool draggingMain = false;
        private Point dragStartMain;

        public FormMain()
        {
            InitializeComponent();

            // Make window borderless
            this.FormBorderStyle = FormBorderStyle.None;

            // Attach drag handlers to the designer top panel if available
            try
            {
                panelUpper_DDE.MouseDown += PanelTopCustom_MouseDown;
                panelUpper_DDE.MouseMove += PanelTopCustom_MouseMove;
            }
            catch { }

            // Create one close button and add it into the designer's top panel so it's visible in designer hierarchy at runtime
            try
            {
                buttonCloseCustom = new Button
                {
                    Text = "Çàêðûòü",
                    AutoSize = true,
                    BackColor = Color.FromArgb(40, 40, 40),
                    FlatStyle = FlatStyle.Popup,
                    ForeColor = Color.WhiteSmoke,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                buttonCloseCustom.Click += (s, e) => this.Close();

                if (panelUpper_DDE != null)
                {
                    panelUpper_DDE.Controls.Add(buttonCloseCustom);
                }
                else
                {
                    // fallback: add to form
                    this.Controls.Add(buttonCloseCustom);
                }

                // position after layout
                this.Shown += (s, e) =>
                {
                    try
                    {
                        if (buttonCloseCustom.Parent != null)
                        {
                            var parentWidth = buttonCloseCustom.Parent.ClientSize.Width;
                            buttonCloseCustom.Location = new Point(parentWidth - buttonCloseCustom.Width - 12, 6);
                            buttonCloseCustom.BringToFront();
                        }
                    }
                    catch { }
                };

                this.Resize += (s, e) =>
                {
                    try
                    {
                        if (buttonCloseCustom.Parent != null)
                        {
                            var parentWidth = buttonCloseCustom.Parent.ClientSize.Width;
                            buttonCloseCustom.Location = new Point(parentWidth - buttonCloseCustom.Width - 12, 6);
                        }
                    }
                    catch { }
                };
            }
            catch { }

            // Improve DataGridView contrast for readability
            try
            {
                dataGridViewBase_DDE.EnableHeadersVisualStyles = false;
                dataGridViewBase_DDE.BackgroundColor = Color.White;
                dataGridViewBase_DDE.GridColor = Color.LightGray;

                dataGridViewBase_DDE.DefaultCellStyle.BackColor = Color.White;
                dataGridViewBase_DDE.DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewBase_DDE.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                dataGridViewBase_DDE.DefaultCellStyle.SelectionForeColor = Color.White;

                dataGridViewBase_DDE.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                dataGridViewBase_DDE.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

                dataGridViewBase_DDE.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                dataGridViewBase_DDE.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                dataGridViewBase_DDE.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                dataGridViewBase_DDE.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
            catch
            {
                // ignore if designer control not yet created in some contexts
            }
        }

        // add method expected by designer
        private void ButtonCloseCustom_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelTopCustom_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draggingMain = true;
                dragStartMain = new Point(e.X, e.Y);
            }
        }

        private void PanelTopCustom_MouseMove(object? sender, MouseEventArgs e)
        {
            if (draggingMain)
            {
                var p = PointToScreen(e.Location);
                this.Location = new Point(p.X - dragStartMain.X, p.Y - dragStartMain.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggingMain = false;
        }

        DataService ds = new DataService();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DataSet.csv");
        //string path = @"C:\Users\djura\Desktop\DataSet.csv";
        static string openFile = string.Empty;
        static int rows = 0;
        static int columns = 0;
        static string[,] matrix = new string[0, 0];
        private void buttonLoad_DDE_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialogMain_DDE.ShowDialog();
                openFile = openFileDialogMain_DDE.FileName;

                matrix = ds.LoadDataSet(openFile);
                rows = matrix.GetLength(0);
                columns = matrix.GetLength(1);
                dataGridViewBase_DDE.RowCount = rows + 1;
                dataGridViewBase_DDE.ColumnCount = columns;


                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewBase_DDE.Rows[i].Cells[j].Value = matrix[i, j];
                        dataGridViewBase_DDE.Rows[i].Cells[j].Selected = false;
                    }
                }

                dataGridViewBase_DDE.Columns[0].Width = 100;
                dataGridViewBase_DDE.Columns[1].Width = 150;
                dataGridViewBase_DDE.Columns[3].Width = 150;
                if (dataGridViewBase_DDE.Columns.Count > 6) dataGridViewBase_DDE.Columns[6].Width = 900;
                buttonReset_DDE.Enabled = true;

            }
            catch
            {
                MessageBox.Show("Âîçíèêëà ïðîáëåìà ñ îòêðûòèåì ôàéëà", "Îøèáêà!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_DDE_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogMain_DDE.FileName = "OutPutFileTask7.csv";
                saveFileDialogMain_DDE.InitialDirectory = Directory.GetCurrentDirectory();

                if (saveFileDialogMain_DDE.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialogMain_DDE.FileName;

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    int rows = dataGridViewBase_DDE.RowCount;
                    int columns = dataGridViewBase_DDE.ColumnCount;

                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewBase_DDE.Rows[i].Cells[j].Value);

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


        private void buttonAbout_DDE_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonSearch_DDE_Click(object sender, EventArgs e)
        {
            dataGridViewBase_DDE.ClearSelection();
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
                            dataGridViewBase_DDE.Rows[i].Selected = true;
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
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
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
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
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
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }


        private void buttonReset_DDE_Click(object sender, EventArgs e)
        {
            for (int v = 0; v < rows; v++)
            {
                dataGridViewBase_DDE.Rows[v].Visible = true;
            }

            dataGridViewBase_DDE.Rows.Clear();
            matrix = ds.LoadDataSet(path);
            rows = matrix.GetLength(0);
            columns = matrix.GetLength(1);
            dataGridViewBase_DDE.RowCount = rows + 1;
            dataGridViewBase_DDE.ColumnCount = columns;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = matrix[i, j];
                    dataGridViewBase_DDE.Rows[i].Cells[j].Selected = false;
                }
            }
            dataGridViewBase_DDE.Columns[0].Width = 100;
            dataGridViewBase_DDE.Columns[1].Width = 150;
            dataGridViewBase_DDE.Columns[3].Width = 150;
        }

        private void ñòîëáåöÄëèòåëüíîñòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] mx = ds.LoadDataSet(path);
            string[,] mxsort = ds.SortUbyv(mx, 2);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
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
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
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
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }


        private void buttonRight_DDE_Click(object sender, EventArgs e)
        {
            dataGridViewBase_DDE.HorizontalScrollingOffset = dataGridViewBase_DDE.HorizontalScrollingOffset + 10;
        }

        private void buttonLeft_DDE_Click(object sender, EventArgs e)
        {
            if (dataGridViewBase_DDE.HorizontalScrollingOffset >= 10)
            {
                dataGridViewBase_DDE.HorizontalScrollingOffset = dataGridViewBase_DDE.HorizontalScrollingOffset - 10;
            }
            else
            {
                dataGridViewBase_DDE.HorizontalScrollingOffset = 0;
            }

        }

        private void buttonFilter_DDE_Click(object sender, EventArgs e)
        {
            if (textBoxFilter_DDE.Text == "")
            {
                MessageBox.Show("Ââåäèòå êðèòåðèé äëÿ ôèëüòðàöèè", "Ïðåäóïðåæäåíèå", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string filterValue = textBoxFilter_DDE.Text.ToLower();
                for (int i = 1; i < dataGridViewBase_DDE.Rows.Count; i++)
                {
                    if (!dataGridViewBase_DDE.Rows[i].IsNewRow)
                    {
                        bool rowShouldBeVisible = false;

                        for (int j = 0; j < dataGridViewBase_DDE.Columns.Count; j++)
                        {
                            var cellValue = dataGridViewBase_DDE.Rows[i].Cells[j].Value?.ToString()?.ToLower();

                            if (cellValue != null && cellValue.IndexOf(filterValue, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                rowShouldBeVisible = true;
                                break;
                            }
                        }
                        for (int q = 0; q < columns; q++)
                        {
                            dataGridViewBase_DDE.Rows[matrix.GetLength(0) - 1].Cells[q].Value = "";

                        }

                        dataGridViewBase_DDE.Rows[i].Visible = rowShouldBeVisible;

                    }
                }
            }
        }

        private void buttonManagement_DDE_Click(object sender, EventArgs e)
        {
            FormManual formmanual = new FormManual();
            formmanual.ShowDialog();
        }

        private void buttonLoad_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonLoad_DDE.BackColor = Color.DarkTurquoise;
            buttonLoad_DDE.ForeColor = Color.Black;
        }

        private void buttonSave_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonSave_DDE.BackColor = Color.DarkTurquoise;
            buttonSave_DDE.ForeColor = Color.Black;
        }

        private void buttonSave_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonSave_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonSave_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonLoad_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonLoad_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonLoad_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonManagement_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonManagement_DDE.BackColor = Color.DarkTurquoise;
            buttonManagement_DDE.ForeColor = Color.Black;
        }

        private void buttonManagement_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonManagement_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonManagement_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonAbout_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonAbout_DDE.BackColor = Color.DarkTurquoise;
            buttonAbout_DDE.ForeColor = Color.Black;
        }

        private void buttonAbout_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonAbout_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonAbout_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonSearch_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonSearch_DDE.BackColor = Color.DarkTurquoise;
            buttonSearch_DDE.ForeColor = Color.Black;
        }

        private void buttonSearch_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonSearch_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonSearch_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonReset_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonReset_DDE.BackColor = Color.DarkTurquoise;

        }

        private void buttonReset_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonReset_DDE.BackColor = Color.FromArgb(60, 60, 60);
        }



        private void buttonGraph_DDE_Click(object sender, EventArgs e)
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
                        dataGridViewBase_DDE.Rows[i].Visible = false;
                        //dataGridViewBase_DDE.Rows.RemoveAt(i);

                    }


                }
                //dataGridViewBase_DDE.Rows.RemoveAt(rows);
                dataGridViewBase_DDE.Rows[rows].Visible = false;

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
                        dataGridViewBase_DDE.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_DDE.Rows[rows].Visible = false;
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
                        dataGridViewBase_DDE.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_DDE.Rows[rows].Visible = false;
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
                        dataGridViewBase_DDE.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_DDE.Rows[rows].Visible = false;
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
                        dataGridViewBase_DDE.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_DDE.Rows[rows].Visible = false;
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
                        dataGridViewBase_DDE.Rows[i].Visible = false;
                    }

                }
                dataGridViewBase_DDE.Rows[rows].Visible = false;

            }
            catch
            {

            }
        }

        private void buttonGraph_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonGraph_DDE.BackColor = Color.DarkTurquoise;
            buttonGraph_DDE.ForeColor = Color.Black;
        }

        private void buttonGraph_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonGraph_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonGraph_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void buttonMenu_DDE_Click(object sender, EventArgs e)
        {
            FormMenu fmen = new FormMenu();

            fmen.TopMost = true;
            fmen.ShowDialog();
        }

        private void buttonMenu_DDE_MouseEnter(object sender, EventArgs e)
        {
            buttonMenu_DDE.BackColor = Color.DarkTurquoise;
            buttonMenu_DDE.ForeColor = Color.Black;
        }

        private void buttonMenu_DDE_MouseLeave(object sender, EventArgs e)
        {
            buttonMenu_DDE.BackColor = Color.FromArgb(40, 40, 40);
            buttonMenu_DDE.ForeColor = Color.WhiteSmoke;
        }

        private void dataGridViewBase_DDE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBoxSort_DDE_Click(object sender, EventArgs e)
        {

        }
    }
}