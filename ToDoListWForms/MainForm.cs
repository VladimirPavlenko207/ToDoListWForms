using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListWForms.Enums;
using ToDoListWForms.Helpers;
using ToDoListWForms.Models.Requests;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms
{
    public partial class MainForm : Form 
    {
        private Operations categoryMode;

        List<CategoryResponseModel> LoadedCategories;
        private bool isBootStrap;

        private bool IsDataChanged { get; set; }
        private string CategoryUrl { get; set; } 
        private string CurrentCategoryName { get; set; }
        private Operations CategoryMode
        {
            get => categoryMode;
            set => SelectCategoryMode(value);
        }

        private void SelectCategoryMode(Operations value)
        {
            CategoryUrl = $"{Program.Url}category";
            categoryMode = value;
            switch (value)
            {
                case Operations.Add:
                    SetCategoryOperation(true, true, false, false, false);
                    CategoryUrl += "/create";
                    break;
                case Operations.Edit:
                    SetCategoryOperation(true, false, false, true, false);
                    CategoryUrl += "/edit";
                    break;
                case Operations.None:
                    bool flag = comboBoxCategorys.SelectedIndex > 0;
                    SetCategoryOperation(false, true, flag, flag, true);
                    break;
                case Operations.Remove:
                    CategoryUrl += "/remove?name=";
                    break;
            }
        }

        private void SetCategoryOperation(bool v1, bool v2, bool v3, bool v4, bool v5)
        {
            textBoxCategory.Visible = v1;
            buttonAddCategory.Enabled = v2;
            buttonDeleteCategory.Enabled = v3;
            buttonEditCategory.Enabled = v4;
            comboBoxCategorys.Enabled = v5;
        }

        public MainForm()
        {
            InitializeComponent();

            SetToolTips();
            textBoxCategory.Visible = false;
            comboBoxRightState.Items.AddRange(new string[] { "Актуальна", "Завершена" });
            comboBoxRightPrior.Items.AddRange(Enum.GetNames(typeof(ThreadPriority)));
            comboBoxRightTags.Visible = false;
            SetButtonsCategory();
            TaskMode = CategoryMode = Operations.None;

            BootstrapAsync();
        }

        private async void BootstrapAsync()
        {
            isBootStrap = true;
            while (!await LoadTagsAsync())
            {
                var mess = "Возможно нет соединения с сервером. Продолжить работу?";
                if (MessageBox.Show(mess, "", MessageBoxButtons.OKCancel) != DialogResult.OK) 
                    Application.Exit();
            }
            _ = LoadCategorysAsync();
        }

        private void SetToolTips()
        {
            ToolTip toolTip1 = new();
            toolTip1.SetToolTip(buttonAddCategory, "Создать новую категорию");
            ToolTip toolTip2 = new();
            toolTip2.SetToolTip(buttonDeleteCategory, "Удалить категорию");
            ToolTip toolTip3 = new();
            toolTip3.SetToolTip(buttonEditCategory, "Редактировать категорию");
            ToolTip toolTip4 = new();
            toolTip4.SetToolTip(textBoxCategory, "После ввода текста нажмите Enter");

            ToolTip toolTip5 = new();
            toolTip5.SetToolTip(buttonAddTag, "Создать новую метку");
            ToolTip toolTip6 = new();
            toolTip6.SetToolTip(buttonDeleteTag, "Удалить метку");
            ToolTip toolTip7 = new();
            toolTip7.SetToolTip(buttonEditTag, "Редактировать метку");
            ToolTip toolTip8 = new();
            toolTip8.SetToolTip(textBoxTag, "После ввода текста нажмите Enter");
        }

        private void SetButtonsCategory()
        {
            buttonDeleteCategory.Enabled = buttonEditCategory.Enabled = comboBoxCategorys.SelectedIndex > 0;
        }

        private async Task LoadCategorysAsync()
        {
            CategoryMode = Operations.None;
            var response = await Task.Run(() => RequestsSender.ClientExecuter(0, CategoryUrl));
            if (response.StatusCode == 0) return;

            LoadedCategories = RequestsSender.GetDeserializedObject(LoadedCategories, response.Content);
            if (LoadedCategories is null) return;

            comboBoxCategorys.Items.Clear();
            comboBoxCategorys.Items.Add("Все категории");
            comboBoxCategorys.Items.AddRange(LoadedCategories.Select(c => c.Name).ToArray());
            comboBoxCategorys.SelectedIndex = 0;

            comboBoxRightCat.Items.Clear();
            comboBoxRightCat.Items.AddRange(LoadedCategories.Select(c => c.Name).ToArray());
            comboBoxRightCat.SelectedIndex = -1;

            _ = LoadTasksAsync();
        }

        private void comboBoxCategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsCategory();
            CurrentCategoryName = comboBoxCategorys.Text;
            DisplayAllTasks();
        }

        /// <summary>
        /// Ограничение длинны строки до n
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static string LengthLimitation(string str, int n)
        {
            return str?.Length > n ? $"{str?.Substring(0, n)}..." : str;
        }

        private async Task CreateNewCategoryAsync()
        {
            if (string.IsNullOrEmpty(textBoxCategory.Text)) return;

            var newCategory = new CategoryRequestModel() { Name = textBoxCategory.Text };
            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, CategoryUrl, newCategory));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await LoadCategorysAsync();
                MessageBox.Show($"Категория \"{newCategory.Name}\" успешно сохранена.");
            }
            else MessageBox.Show(response.Content);
        }

        private void textBoxCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                var newName = (sender as TextBox).Text.Trim();
                if (string.IsNullOrEmpty(newName) || newName == CurrentCategoryName) return;

                string mes;
                switch (CategoryMode)
                {
                    case Operations.Add:
                        mes = $"Вы действительно хотите создать категорию \"{newName}\"?";
                        if (MessageBox.Show(mes, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            _ = CreateNewCategoryAsync();
                        break;
                    case Operations.Edit:
                        mes = $"Вы действительно хотите редактировать категорию \"{comboBoxCategorys.Text}\"?";
                        if (MessageBox.Show(mes, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            _ = EditCategoryAsync();
                        break;
                }
            }
        }

        private async Task EditCategoryAsync()
        {
            var category = new CategoryRequestModel() 
            {
                Name = comboBoxCategorys.Text,
                NewName = textBoxCategory.Text 
            };
            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, CategoryUrl, category));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await LoadCategorysAsync();
                MessageBox.Show($"Категория \"{category.Name}\" успешно исправленна на \"{category.NewName}\".");
            }
            else MessageBox.Show(response.Content);
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            CategoryMode = CategoryMode == Operations.Add ?
                Operations.None : Operations.Add;
            textBoxCategory.Clear();
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            RemoveCategoryAsync();
        }

        private async void RemoveCategoryAsync()
        {
            var mess = $"Удалить категорию \"{comboBoxCategorys.Text}\"?";
            if (MessageBox.Show(mess, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            CategoryMode = Operations.Remove;

            var name = comboBoxCategorys.Text;
            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, CategoryUrl + name));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await LoadCategorysAsync();
                MessageBox.Show($"Категория \"{name}\" успешно удалена.");
            }
            else MessageBox.Show(response.Content);
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            CategoryMode = CategoryMode == Operations.Edit ?
               Operations.None : Operations.Edit;
            textBoxCategory.Text = comboBoxCategorys.Text;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ClearCurrentTaskView();
           
            if (dataGridView1.SelectedRows.Count == 0)
            {
                CurrentTask = null;
                return;
            }
            var id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            CurrentTask = LoadedTasks.FirstOrDefault(t => t.Id == id);
            TaskMode = Operations.None;
            IsDataChanged = false;
        }

        private void ClearCurrentTaskView()
        {
            textBoxRightTask.Clear();
            comboBoxRightCat.SelectedIndex = -1;
            comboBoxRightPrior.SelectedIndex = -1;
            dateTimePickerRightDeadline.Value = DateTime.Now;
            comboBoxRightState.SelectedIndex = -1;
            listBoxRightTags.Items?.Clear();
            comboBoxRightTags.SelectedIndex = -1;
        }

        private void textBoxLeftTask_TextChanged(object sender, EventArgs e)
        {
            IsDataChanged = true;
        }

        private void comboBoxLeftCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDataChanged = true;
        }

        private void comboBoxLeftPrior_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDataChanged = true;
        }

        private void comboBoxLeftState_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDataChanged = true;
        }

        private void dateTimePickerLeftDeadline_ValueChanged(object sender, EventArgs e)
        {
            IsDataChanged = true;
        }

        private void buttonSaveTask_Click(object sender, EventArgs e)
        {
            if (!IsDataChanged) return;
            _ = SaveCurrentTaskAsync();
            IsDataChanged = false;
        }

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            IsDataChanged = false;
            _ = DeleteCurrentTaskAsync();
        }

        private void buttonleftAddTag_Click(object sender, EventArgs e)
        {
            comboBoxRightTags.Visible = !comboBoxRightTags.Visible;
        }

        private void buttonLeftRemoveTag_Click(object sender, EventArgs e)
        {
            var item = listBoxRightTags.SelectedItem;
            var message = $"Удалить метку \"{item}\"?";
            if (MessageBox.Show(message, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            listBoxRightTags.Items.Remove(item);
            IsDataChanged = true;
        }

        private void comboBoxLeftTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRightTags.SelectedIndex < 0) return;

            var tagName = comboBoxRightTags.Text;
            string[] currentTaskTags = new string[listBoxRightTags.Items.Count];
            for (int i = 0; i < currentTaskTags.Length; i++)
            {
                currentTaskTags[i] = listBoxRightTags.Items[i].ToString();
            }
            if (currentTaskTags.Any(i => i == tagName))
            {
                MessageBox.Show($"В этой задаче метка \"{tagName}\" уже добавлена.");
                return;
            }
            listBoxRightTags.Items.Add(tagName);
            comboBoxRightTags.Visible = false;
            IsDataChanged = true;
        }

        private void listBoxRightTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRightRemoveTag.Enabled = listBoxRightTags.SelectedIndex >= 0 &&
                (TaskMode == Operations.Edit || TaskMode == Operations.Add);
        }

        private void buttonUpDate_Click(object sender, EventArgs e)
        {
            BootstrapAsync();
        }
    }
}
