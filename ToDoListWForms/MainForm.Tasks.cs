using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private Operations taskMode;
        private TaskResponseModel currentTask;

        private List<TaskResponseModel> LoadedTasks { get; set; }
        private string TaskUrl { get; set; }
        private TaskResponseModel CurrentTask
        {
            get => currentTask;
            set => SetCurrentTask(value);
        }

        private void SetCurrentTask(TaskResponseModel value)
        {
            IsDataChanged = false;
            currentTask = value;
            if (currentTask is null)
            {
                radioButtonAddTask.Checked = true;
                RadioButtonsConfig(false, false);
                TaskMode = Operations.Add;
            }
            else
            {
                radioButtonViewTask.Checked = true;
                RadioButtonsConfig(true, true);
            }
        }

        private void RadioButtonsConfig(bool v1, bool v2)
        {
            radioButtonEditTask.Enabled = v1;
            radioButtonViewTask.Enabled = v2;
        }

        private Operations TaskMode
        {
            get => taskMode;
            set => SelectTaskMode(value);
        }

        private void SelectTaskMode(Operations value)
        {
            TaskUrl = $"{Program.Url}Task";
            taskMode = value;
            ClearCurrentTaskView();
            switch (value)
            {
                case Operations.Add:
                    SetTaskOperation(true, false, false);
                    TaskUrl += "/create";
                    break;
                case Operations.Edit:
                    DisplaySelectedTask();
                    SetTaskOperation(true, true, true);
                    TaskUrl += "/edit";
                    break;
                case Operations.None:
                    DisplaySelectedTask();
                    SetTaskOperation(false, true, false);
                    break;
                case Operations.Remove:
                    TaskUrl += $"/remove?id={CurrentTask.Id}";
                    break;
            }
            IsDataChanged = false;
        }

        private void SetTaskOperation(bool v1, bool v2, bool v3)
        {
            textBoxRightTask.ReadOnly = !v1;
            comboBoxRightCat.Enabled = v1;
            comboBoxRightPrior.Enabled = v1;
            dateTimePickerRightDeadline.Enabled = v1;
            buttonRightAddTag.Enabled = v1;
            comboBoxRightTags.Visible = false;
            buttonRightRemoveTag.Enabled = false;

            buttonDeleteTask.Enabled = v2;
            comboBoxRightState.Enabled = v3;
        }

        private async Task LoadTasksAsync()
        {
            isBootStrap = false;

            TaskMode = Operations.None;
            var response = await Task.Run(() => RequestsSender.ClientExecuter(0, TaskUrl));
            if (response.StatusCode == 0) return;

            LoadedTasks = RequestsSender.GetDeserializedObject(LoadedTasks, response.Content);
            if (LoadedTasks is null) return;
            if (LoadedTasks.Count == 0) CurrentTask = null;

            DisplayAllTasks();
        }

        private void DisplayAllTasks()
        {
            var tasks = SelectTasks();
            if (tasks is null) return;

            int count = 0;
            dataGridView1.Rows.Clear();
            foreach (var task in tasks)
            {
                dataGridView1.Rows.Add(
                    ++count,
                    LengthLimitation(task.Description, 20),
                    task.Id,
                    task.Category.Name,
                    task.Priority,
                    task.Deadline,
                    task.IsComplete
                    );
            }
        }

        private List<TaskResponseModel> SelectTasks()
        {
            if (comboBoxCategorys.SelectedIndex > 0 && comboBoxTags.SelectedIndex == 0)
                return LoadedTasks.Where(t => t.Category.Name == comboBoxCategorys.Text).ToList();

            var tagName = comboBoxTags.Text;
            if (comboBoxCategorys.SelectedIndex == 0 && comboBoxTags.SelectedIndex > 0)
                return LoadedTasks.Where(t => t.Tags.Any(t => t.Name == tagName)).ToList(); 

            if (comboBoxCategorys.SelectedIndex > 0 && comboBoxTags.SelectedIndex > 0)
                return LoadedTasks.
                    Where(t => t.Category.Name == comboBoxCategorys.Text &&
                    t.Tags.Any(t => t.Name == tagName)).ToList();

            else return LoadedTasks;
        }

        private void DisplaySelectedTask()
        {
            if (CurrentTask is null) return;

            textBoxRightTask.Text = CurrentTask.Description;
            comboBoxRightCat.SelectedItem = CurrentTask.Category.Name;
            comboBoxRightPrior.SelectedItem = CurrentTask.Priority.ToString();
            dateTimePickerRightDeadline.Value = CurrentTask.Deadline.Value;
            comboBoxRightState.SelectedIndex = Convert.ToInt32(CurrentTask.IsComplete);

            listBoxRightTags.Items.Clear();
            if (CurrentTask.Tags.Count > 0)
                listBoxRightTags.Items.AddRange(CurrentTask.Tags.Select(t => t.Name).ToArray());

            buttonRightRemoveTag.Enabled = CurrentTask.Tags.Count > 0 &&
                (TaskMode == Operations.Edit || TaskMode == Operations.Add);
        }

        private async void radioButtonsTask_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (!rb.Checked) return;

            if (IsDataChanged) await SaveCurrentTaskAsync();

            if (rb == radioButtonViewTask) TaskMode = Operations.None;
            if (rb == radioButtonAddTask) TaskMode = Operations.Add;
            if (rb == radioButtonEditTask) TaskMode = Operations.Edit;
        }

        private async Task SaveCurrentTaskAsync()
        {
            var message = "Сохранить изменения в базе?";
            if (MessageBox.Show(message, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            if (!CorrectnessChecking()) return;

            var task = new TaskRequestModel()
            {
                Description = textBoxRightTask.Text,
                Priority = comboBoxRightPrior.SelectedIndex,
                Deadline = dateTimePickerRightDeadline.Value.ToString(),
                CategoryName = comboBoxRightCat.Text,
                IsComplete = Convert.ToBoolean(comboBoxRightState.SelectedIndex),
                TagsNames = SelectNewTaskTags()
            };
            if (TaskMode == Operations.Edit) task.Id = currentTask.Id;

            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, TaskUrl, task));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _ = LoadTasksAsync();
                MessageBox.Show($"Задача \"{ LengthLimitation(task.Description, 20)}\" успешно сохранена.");
            }
            else MessageBox.Show(response.Content);
            TaskMode = Operations.None;
        }

        private bool CorrectnessChecking()
        {
            if (textBoxRightTask.Text.Trim().Length > 0 &&
                comboBoxRightPrior.SelectedIndex >= 0 &&
                comboBoxRightCat.SelectedIndex >= 0) return true;

            MessageBox.Show("Не все поля заполнены!");
            return false;
        }

        private List<string> SelectNewTaskTags()
        {
            List<string> tagsNames = new();
            foreach (var item in listBoxRightTags.Items)
            {
                tagsNames.Add(item.ToString());
            }
            return tagsNames;
        }

        private async Task DeleteCurrentTaskAsync()
        {
            TaskMode = Operations.Remove;
            var message = "Удалить текущую задачу?";
            if (MessageBox.Show(message, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, TaskUrl));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show($"Задача \"{ LengthLimitation(CurrentTask.Description, 20)}\" успешно удалена.");
                _ = LoadTasksAsync();
            }
            else MessageBox.Show(response.Content);
        }


    }
}
