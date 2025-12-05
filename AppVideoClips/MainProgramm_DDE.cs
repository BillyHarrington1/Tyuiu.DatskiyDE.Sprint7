using AppVideoClips.Lib;

namespace AppVideoClips
{
    public partial class MainProgramm_DDE : Form
    {
        public MainProgramm_DDE()
        {
            InitializeComponent();
        }

        private void MainProgramm_DDE_Load(object sender, EventArgs e)
        {
            DataService.EnsureDefaultFileExists();
            LoadCatalogAndRefresh();
        }

        private void LoadCatalogAndRefresh()
        {
            try
            {
                DataService.Catalog.Load(DataService.DefaultCsvPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке CSV: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshTiles();
            UpdateStatus();
        }

        private void RefreshTiles(string searchQuery = "")
        {
            flowLayoutPanelTiles_DDE.SuspendLayout();
            flowLayoutPanelTiles_DDE.Controls.Clear();

            var items = string.IsNullOrWhiteSpace(searchQuery)
                ? DataService.Catalog.Items
                : DataService.Catalog.Search(searchQuery).ToList();

            foreach (var clip in items)
            {
                var card = new ClipCardControl_DDE();
                card.Bind(clip);
                card.Tag = clip.Id;

                // Double click to edit
                card.DoubleClick += (s, e) => EditClipById(clip.Id);

                // Context menu
                var cms = new ContextMenuStrip();
                var miEdit = new ToolStripMenuItem("Редактировать");
                miEdit.Click += (s, e) => EditClipById(clip.Id);
                var miDelete = new ToolStripMenuItem("Удалить");
                miDelete.Click += (s, e) => DeleteClipByIdWithConfirm(clip.Id);

                cms.Items.AddRange(new ToolStripItem[] { miEdit, miDelete });
                card.ContextMenuStrip = cms;

                flowLayoutPanelTiles_DDE.Controls.Add(card);
            }

            flowLayoutPanelTiles_DDE.ResumeLayout();
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            labelStatus_DDE.Text = $"Записей: {DataService.Catalog.Count()}";
        }

        private void buttonLoad_DDE_Click(object sender, EventArgs e)
        {
            LoadCatalogAndRefresh();
            MessageBox.Show("Загружено.", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSave_DDE_Click(object sender, EventArgs e)
        {
            try
            {
                DataService.Catalog.Save(DataService.DefaultCsvPath);
                MessageBox.Show("Сохранено в " + DataService.DefaultCsvPath, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_DDE_Click(object sender, EventArgs e)
        {
            var dlg = new EditClipForm_DDE();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                DataService.Catalog.Add(dlg.Clip);
                RefreshTiles();
                UpdateStatus();
            }
        }

        private void EditClipById(int id)
        {
            var clip = DataService.Catalog.Items.FirstOrDefault(x => x.Id == id);
            if (clip == null) return;
            var dlg = new EditClipForm_DDE(clip);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                DataService.Catalog.Update(dlg.Clip);
                RefreshTiles();
                UpdateStatus();
            }
        }

        private void DeleteClipByIdWithConfirm(int id)
        {
            if (MessageBox.Show($"Удалить запись #{id}?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataService.Catalog.Delete(id);
                RefreshTiles();
                UpdateStatus();
            }
        }

        private void buttonDelete_DDE_Click(object sender, EventArgs e)
        {
            // Если пользователь выделил плитку — удаляем её
            if (flowLayoutPanelTiles_DDE.Controls.Count == 0) return;

            // Попытка найти выделенную (фокус) плитку
            var focused = flowLayoutPanelTiles_DDE.Controls.Cast<Control>().FirstOrDefault(c => c.Focused);
            if (focused != null && focused.Tag is int id)
            {
                DeleteClipByIdWithConfirm(id);
                return;
            }

            // Иначе спросим id
            var input = Microsoft.VisualBasic.Interaction.InputBox("Введите Id записи для удаления:", "Удаление", "");
            if (int.TryParse(input, out var parsed))
            {
                DeleteClipByIdWithConfirm(parsed);
            }
        }

        private void buttonSearch_DDE_Click(object sender, EventArgs e)
        {
            var q = textBoxSearch_DDE.Text;
            RefreshTiles(q);
        }

        private void textBoxSearch_DDE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_DDE.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void buttonCharts_DDE_Click(object sender, EventArgs e)
        {
            var frm = new StatsForm_DDE();
            frm.ShowDialog(this);
        }

        private void buttonChartDuration_DDE_Click(object sender, EventArgs e)
        {
            var frm = new StatsForm_DDE(); // StatsForm показывает гистограмму по длительности
            frm.ShowDialog(this);
        }

        private void buttonChartCost_DDE_Click(object sender, EventArgs e)
        {
            // Временно переиспользуем StatsForm (можно расширить позже)
            var frm = new StatsForm_DDE();
            frm.ShowDialog(this);
        }

        private void buttonAbout_DDE_Click(object sender, EventArgs e)
        {
            var frm = new AboutMe_DDE();
            frm.ShowDialog(this);
        }

        private void flowLayoutPanelTiles_DDE_ControlAdded(object sender, ControlEventArgs e)
        {
            // можно добавить анимацию/эффект — пока обновляем статус
            UpdateStatus();
        }

        private void buttonExport_DDE_Click(object sender, EventArgs e)
        {
            // Экспорт текущего каталога как CSV (save as)
            using var sfd = new SaveFileDialog()
            {
                Title = "Экспорт CSV",
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "videoclips_export.csv"
            };
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    DataService.Catalog.Save(sfd.FileName);
                    MessageBox.Show("Экспорт сохранён: " + sfd.FileName, "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
