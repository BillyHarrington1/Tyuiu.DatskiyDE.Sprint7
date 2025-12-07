using AppVideoClips.Lib;
using System.Text;
using FontAwesome.Sharp;
namespace AppVideoClips
{
    public partial class FormMain : Form
    {
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

            // assign FontAwesome icons to picture boxes
            try
            {
                pictureBoxLoad_DDE.Image = CreateFaIconBitmap(IconChar.FolderOpen, 40, Color.White);
                pictureBoxSave_DDE.Image = CreateFaIconBitmap(IconChar.FileExport, 40, Color.White);
                pictureBoxManagement_DDE.Image = CreateFaIconBitmap(IconChar.Book, 40, Color.White);
                pictureBoxAbout_DDE.Image = CreateFaIconBitmap(IconChar.InfoCircle, 40, Color.White);
                pictureBoxSort_DDE.Image = CreateFaIconBitmap(IconChar.SortAmountDown, 34, Color.White);
                pictureBoxFilter_DDE.Image = CreateFaIconBitmap(IconChar.Filter, 40, Color.White);
                pictureBoxSearch_DDE.Image = CreateFaIconBitmap(IconChar.Search, 40, Color.White);
            }
            catch { }

            // add context menu to copy selected row
            try
            {
                var cms = new ContextMenuStrip();
                var miCopyRow = new ToolStripMenuItem("Копировать строку");
                miCopyRow.Click += (s, e) => CopySelectedRowToClipboard();
                cms.Items.Add(miCopyRow);
                dataGridViewBase_DDE.ContextMenuStrip = cms;
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

        private Bitmap CreateFaIconBitmap(IconChar iconChar, int size, Color color)
        {
            using var ipb = new IconPictureBox();
            ipb.IconChar = iconChar;
            ipb.IconColor = color;
            ipb.IconSize = size;
            ipb.BackColor = Color.Transparent;
            ipb.Size = new Size(size, size);
            var bmp = new Bitmap(size, size);
            ipb.DrawToBitmap(bmp, new Rectangle(0, 0, size, size));
            return bmp;
        }

        private void CopySelectedRowToClipboard()
        {
            try
            {
                if (dataGridViewBase_DDE.SelectedRows.Count == 0) return;
                var row = dataGridViewBase_DDE.SelectedRows[0];
                var parts = new List<string>();
                for (int i = 0; i < row.Cells.Count; i++) parts.Add(row.Cells[i].Value?.ToString() ?? string.Empty);
                var line = string.Join(";", parts);
                Clipboard.SetText(line);
                toolTipButtons_DDE.Show("Строка скопирована в буфер обмена", dataGridViewBase_DDE, 2000);
            }
            catch { }
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

                if (dataGridViewBase_DDE.Columns.Count > 0) dataGridViewBase_DDE.Columns[0].Width = 100;
                if (dataGridViewBase_DDE.Columns.Count > 1) dataGridViewBase_DDE.Columns[1].Width = 150;
                if (dataGridViewBase_DDE.Columns.Count > 3) dataGridViewBase_DDE.Columns[3].Width = 150;
                if (dataGridViewBase_DDE.Columns.Count > 6) dataGridViewBase_DDE.Columns[6].Width = 900;
                buttonReset_DDE.Enabled = true;

                // populate filter menu dynamically with headers from CSV
                try
                {
                    фильтрToolStripMenuItem.DropDownItems.Clear();
                    // Add reset filter item
                    var reset = new ToolStripMenuItem("Сбросить фильтр");
                    reset.Click += ResetFilter_Click;
                    фильтрToolStripMenuItem.DropDownItems.Add(reset);
                    фильтрToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

                    for (int c = 0; c < columns; c++)
                    {
                        var header = matrix[0, c] ?? $"Столбец {c}";
                        var item = new ToolStripMenuItem(header) { Tag = c };
                        item.Click += FilterByColumn_Click;
                        фильтрToolStripMenuItem.DropDownItems.Add(item);
                    }
                }
                catch { }

            }
            catch
            {
                MessageBox.Show("Возникла проблема с открытием файла", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterByColumn_Click(object? sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem it) || matrix == null || matrix.Length == 0) return;
            if (!(it.Tag is int col)) return;
            string fv = textBoxFilter_DDE.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(fv))
            {
                MessageBox.Show("Введите критерий для фильтрации", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int r = 1; r < rows; r++)
            {
                var cell = matrix[r, col] ?? string.Empty;
                dataGridViewBase_DDE.Rows[r].Visible = cell.IndexOf(fv, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private void ResetFilter_Click(object? sender, EventArgs e)
        {
            try
            {
                for (int r = 1; r < dataGridViewBase_DDE.Rows.Count; r++)
                {
                    if (!dataGridViewBase_DDE.Rows[r].IsNewRow)
                        dataGridViewBase_DDE.Rows[r].Visible = true;
                }
            }
            catch { }
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

                    if (File.Exists(path)) File.Delete(path);

                    int rows = dataGridViewBase_DDE.RowCount;
                    int columns = dataGridViewBase_DDE.ColumnCount;

                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewBase_DDE.Rows[i].Cells[j].Value);
                            if (j != columns - 1) strBuilder.Append(";");
                        }
                        strBuilder.AppendLine();
                    }

                    File.WriteAllText(path, strBuilder.ToString(), Encoding.UTF8);

                    MessageBox.Show("Файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить файл. Ошибка: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrWhiteSpace(textBoxSearch_DDE.Text))
            {
                MessageBox.Show("Введите критерий для поиска", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!string.IsNullOrEmpty(matrix[i, j]) && matrix[i, j].IndexOf(textBoxSearch_DDE.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        dataGridViewBase_DDE.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }

        // Sorting handlers will use DataService's robust methods
        private void сортировкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                var src = (matrix != null && matrix.Length > 0) ? matrix : ds.LoadDataSet(path);
                var mxsort = ds.SortVozr(src, 2);
                ApplySortedMatrixToGrid(mxsort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void столбецВесToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var src = (matrix != null && matrix.Length > 0) ? matrix : ds.LoadDataSet(path);
                var mxsort = ds.SortVozr(src, 5);
                ApplySortedMatrixToGrid(mxsort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void столбецIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var src = (matrix != null && matrix.Length > 0) ? matrix : ds.LoadDataSet(path);
                var mxsort = ds.SortVozr(src, 0);
                ApplySortedMatrixToGrid(mxsort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplySortedMatrixToGrid(string[,] mxsort)
        {
            if (mxsort == null) return;
            int rcount = mxsort.GetLength(0);
            int ccount = mxsort.GetLength(1);
            dataGridViewBase_DDE.RowCount = rcount + 1;
            dataGridViewBase_DDE.ColumnCount = ccount;
            for (int i = 0; i < rcount; i++)
            {
                for (int j = 0; j < ccount; j++)
                {
                    dataGridViewBase_DDE.Rows[i].Cells[j].Value = mxsort[i, j];
                }
            }
        }

        private void buttonReset_DDE_Click(object sender, EventArgs e)
        {
            try
            {
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
                        dataGridViewBase_DDE.Rows[i].Visible = true;
                    }
                }

                if (dataGridViewBase_DDE.Columns.Count > 0) dataGridViewBase_DDE.Columns[0].Width = 100;
                if (dataGridViewBase_DDE.Columns.Count > 1) dataGridViewBase_DDE.Columns[1].Width = 150;
                if (dataGridViewBase_DDE.Columns.Count > 3) dataGridViewBase_DDE.Columns[3].Width = 150;
            }
            catch { }
        }

        private void столбецДлительностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var src = (matrix != null && matrix.Length > 0) ? matrix : ds.LoadDataSet(path);
                var mxsort = ds.SortUbyv(src, 2);
                ApplySortedMatrixToGrid(mxsort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void столбецВесToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var src = (matrix != null && matrix.Length > 0) ? matrix : ds.LoadDataSet(path);
                var mxsort = ds.SortUbyv(src, 5);
                ApplySortedMatrixToGrid(mxsort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void столбецДатаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var src = (matrix != null && matrix.Length > 0) ? matrix : ds.LoadDataSet(path);
                var mxsort = ds.SortUbyv(src, 0);
                ApplySortedMatrixToGrid(mxsort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrWhiteSpace(textBoxFilter_DDE.Text))
            {
                MessageBox.Show("Введите критерий для фильтрации", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filterValue = textBoxFilter_DDE.Text;
            for (int i = 1; i < dataGridViewBase_DDE.Rows.Count; i++)
            {
                var row = dataGridViewBase_DDE.Rows[i];
                if (row.IsNewRow) continue;
                bool visible = false;
                for (int j = 0; j < dataGridViewBase_DDE.Columns.Count; j++)
                {
                    var cell = row.Cells[j].Value?.ToString();
                    if (!string.IsNullOrEmpty(cell) && cell.IndexOf(filterValue, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        visible = true; break;
                    }
                }
                row.Visible = visible;
            }
        }

        private void buttonManagement_DDE_Click(object sender, EventArgs e)
        {
            FormManual formmanual = new FormManual();
            formmanual.ShowDialog();
        }

        // filter menu handlers: use matrix and bounds-check
        private void названиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (columns <= 1) return;
                string fv = textBoxFilter_DDE.Text;
                for (int i = 1; i < rows; i++) if (!(matrix[i, 1] ?? string.Empty).Contains(fv, StringComparison.OrdinalIgnoreCase)) dataGridViewBase_DDE.Rows[i].Visible = false;
            }
            catch { }
        }

        private void весToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (columns <= 5) return;
                string fv = textBoxFilter_DDE.Text;
                for (int i = 1; i < rows; i++) if (!(matrix[i, 5] ?? string.Empty).Contains(fv, StringComparison.OrdinalIgnoreCase)) dataGridViewBase_DDE.Rows[i].Visible = false;
            }
            catch { }
        }

        private void длительностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (columns <= 2) return;
                string fv = textBoxFilter_DDE.Text;
                for (int i = 1; i < rows; i++) if (!(matrix[i, 2] ?? string.Empty).Contains(fv, StringComparison.OrdinalIgnoreCase)) dataGridViewBase_DDE.Rows[i].Visible = false;
            }
            catch { }
        }

        private void форматToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (columns <= 3) return;
                string fv = textBoxFilter_DDE.Text;
                for (int i = 1; i < rows; i++) if (!(matrix[i, 3] ?? string.Empty).Contains(fv, StringComparison.OrdinalIgnoreCase)) dataGridViewBase_DDE.Rows[i].Visible = false;
            }
            catch { }
        }

        private void категорияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (columns <= 6) return;
                string fv = textBoxFilter_DDE.Text;
                for (int i = 1; i < rows; i++) if (!(matrix[i, 6] ?? string.Empty).Contains(fv, StringComparison.OrdinalIgnoreCase)) dataGridViewBase_DDE.Rows[i].Visible = false;
            }
            catch { }
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (columns <= 0) return;
                string fv = textBoxFilter_DDE.Text;
                for (int i = 1; i < rows; i++) if (!(matrix[i, 0] ?? string.Empty).Contains(fv, StringComparison.OrdinalIgnoreCase)) dataGridViewBase_DDE.Rows[i].Visible = false;
            }
            catch { }
        }

        private void buttonAbout_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonAbout_DDE.BackColor = Color.DarkTurquoise; buttonAbout_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonAbout_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonAbout_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonAbout_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

        private void buttonSave_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonSave_DDE.BackColor = Color.DarkTurquoise; buttonSave_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonSave_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonSave_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonSave_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

        private void buttonManagement_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonManagement_DDE.BackColor = Color.DarkTurquoise; buttonManagement_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonManagement_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonManagement_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonManagement_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

        private void buttonLoad_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonLoad_DDE.BackColor = Color.DarkTurquoise; buttonLoad_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonLoad_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonLoad_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonLoad_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

        private void buttonMenu_DDE_Click(object sender, EventArgs e)
        {
            try
            {
                FormMenu fmen = new FormMenu();
                fmen.TopMost = true;
                fmen.ShowDialog();
            }
            catch { }
        }

        private void buttonMenu_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonMenu_DDE.BackColor = Color.DarkTurquoise; buttonMenu_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonMenu_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonMenu_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonMenu_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

        private void pictureBoxSort_DDE_Click(object sender, EventArgs e)
        {
            // optional: toggle visibility of menuStripSort_DDE
            try { menuStripSort_DDE.Visible = !menuStripSort_DDE.Visible; } catch { }
        }

        private void buttonReset_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonReset_DDE.BackColor = Color.DarkTurquoise; } catch { }
        }

        private void buttonReset_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonReset_DDE.BackColor = Color.FromArgb(60, 60, 60); } catch { }
        }

        private void dataGridViewBase_DDE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // placeholder
        }

        private void buttonGraph_DDE_Click(object sender, EventArgs e)
        {
            try { FormGraph fg = new FormGraph(); fg.Show(); } catch { }
        }

        private void buttonGraph_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonGraph_DDE.BackColor = Color.DarkTurquoise; buttonGraph_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonGraph_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonGraph_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonGraph_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

        private void buttonSearch_DDE_MouseEnter(object sender, EventArgs e)
        {
            try { buttonSearch_DDE.BackColor = Color.DarkTurquoise; buttonSearch_DDE.ForeColor = Color.Black; } catch { }
        }

        private void buttonSearch_DDE_MouseLeave(object sender, EventArgs e)
        {
            try { buttonSearch_DDE.BackColor = Color.FromArgb(40, 40, 40); buttonSearch_DDE.ForeColor = Color.WhiteSmoke; } catch { }
        }

    }
}