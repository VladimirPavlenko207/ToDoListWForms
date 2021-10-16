using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListWForms.Controllers;
using ToDoListWForms.Helpers;
using ToDoListWForms.Models.Requests;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms
{
    public partial class MainForm : Form 
    {
        private static MainForm _instance;

        private readonly BaseController _tagController = new TagController();
        private readonly BaseController _categoryController = new CategoryController();
        private readonly TaskController _taskController = new TaskController();

        //private bool IsDataChanged { get; set; }

        private MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получаем экземпляр главного окна
        /// </summary>
        /// <returns></returns>
        public static MainForm GetInstance()
        {
            return _instance ??= new MainForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolTipsCreator.SetAllToolTips();
            BootstrapAsync();
        }

        private async void BootstrapAsync()
        {
            while (!await LoadTagsAsync())
            {
                var mess = "Возможно нет соединения с сервером. Продолжить работу?";
                if(!MessageBoxHelper.SendOkCancelMessage(mess)) Application.Exit();
            }
             LoadCategorys();
        }

        private void LoadCategorys()
        {
            _categoryController.SetLoadMode();
            _ = _categoryController.LoadAsync();
            LoadTasks();
        }

        private void LoadTasks()
        {
            _taskController.SetLoadMode();
            _ = _taskController.LoadAsync();
        }

        private void comboBoxCategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            _categoryController.SetLoadMode();
            _categoryController.Display();
            _taskController.DisplayAllTasks();
        }

        private void textBoxCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                UpdateLoadAndLoadTasksAsync(_categoryController);
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            _categoryController.AddModeTrigger();
            _categoryController.Display();
        }

        private void buttonRemoveCategory_Click(object sender, EventArgs e)
        {
            _categoryController.SetRemoveMode();
            UpdateLoadAndLoadTasksAsync(_categoryController);
        }
         
        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            _categoryController.EditModeTrigger();
            _categoryController.Display();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           // IsDataChanged = false;

            _taskController.SetLoadMode();
             _taskController.GetCurrentTask();
            _taskController.Display();
            //IsDataChanged = false;
        }

        private void textBoxLeftTask_TextChanged(object sender, EventArgs e)
        {
            //IsDataChanged = true;
        }

        private void comboBoxLeftCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IsDataChanged = true;
        }

        private void comboBoxLeftPrior_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IsDataChanged = true;
        }

        private void comboBoxLeftState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IsDataChanged = true;
        }

        private void dateTimePickerLeftDeadline_ValueChanged(object sender, EventArgs e)
        {
            //IsDataChanged = true;
        }

        private void buttonSaveTask_Click(object sender, EventArgs e)
        {
            UpdateLoadAndLoadTasksAsync(_taskController);
            // IsDataChanged = false;
        }

        private void buttonRemoveTask_Click(object sender, EventArgs e)
        {
            //IsDataChanged = false;
            _taskController.SetRemoveMode();
            UpdateLoadAndLoadTasksAsync(_taskController);
        }

        private void buttonRightAddTag_Click(object sender, EventArgs e)
        {
            _taskController.ShowTagList();
        }

        private void buttonRightRemoveTag_Click(object sender, EventArgs e)
        {
            _taskController.RemoveTagFromTask();

            //IsDataChanged = true;
        }

        private void comboBoxRightTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            _taskController.AddCurrentTaskTag();

           // IsDataChanged = true;
        }

        private void listBoxRightTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            _taskController.ButtonRemoveTaskTagTrigger(); 
        }

        private void buttonUpDate_Click(object sender, EventArgs e)
        {
            BootstrapAsync();
        }


        private void radioButtonsTask_CheckedChanged(object sender, EventArgs e)
        {
            _taskController.RadioButtonsTrigger(sender);
            _taskController.Display();
        }

        internal RadioButton GetCheckedRadioButton(object sender)
        {
            return sender as RadioButton;
        }

        private async Task<bool> LoadTagsAsync()
        {
            _tagController.SetLoadMode();
            return await _tagController.LoadAsync();
        }

        private void comboBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tagController.SetLoadMode();
            _tagController.Display();
            _taskController.DisplayAllTasks();
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            _tagController.AddModeTrigger();
            _tagController.Display();
        }

        private void buttonRemoveTag_Click(object sender, EventArgs e)
        {
            _tagController.SetRemoveMode();
            UpdateLoadAndLoadTasksAsync(_tagController);
        }

        private async void UpdateLoadAndLoadTasksAsync(BaseController controller)
        {
            var message = await controller.UpdateAndLoadAsync();
            if (!string.IsNullOrEmpty(message))
            {
                LoadTasks();
                MessageBox.Show(message);
            }
        }

        private void buttonEditTag_Click(object sender, EventArgs e)
        {
            _tagController.EditModeTrigger();
            _tagController.Display();
        }

        private void textBoxTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                UpdateLoadAndLoadTasksAsync(_tagController);
            }
        }
    }
}
