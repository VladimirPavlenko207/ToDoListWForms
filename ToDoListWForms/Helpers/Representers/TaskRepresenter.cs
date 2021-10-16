using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoListWForms.Models.Requests;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms.Helpers.Representers
{
    public class TaskRepresenter
    {
        internal void PresentLoadTaskMode()
        {
            SetControlsState(false, true, false);
        }

        internal void PresentEditTaskMode()
        {
            SetControlsState(true, true, true);
        }

        internal void PresentAddTaskMode()
        {
            SetControlsState(true, false, false);
        }

        internal int GetCurrentTaskId()
        {
            var dgv = MainForm.GetInstance().dataGridView1;
            if (dgv.SelectedRows.Count == 0) return 0;

            return Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
        }

        private void SetControlsState(bool v1, bool v2, bool v3)
        {
            ClearCurrentTaskView();

            MainForm.GetInstance().textBoxRightTask.ReadOnly = !v1;
            MainForm.GetInstance().comboBoxRightCat.Enabled = v1;
            MainForm.GetInstance().comboBoxRightPrior.Enabled = v1;
            MainForm.GetInstance().dateTimePickerRightDeadline.Enabled = v1;
            MainForm.GetInstance().buttonRightAddTag.Enabled = v1;
            MainForm.GetInstance().comboBoxRightTags.Visible = false;
            MainForm.GetInstance().buttonRightRemoveTag.Enabled = false;

            MainForm.GetInstance().buttonSaveTask.Enabled = v1;
            MainForm.GetInstance().buttonDeleteTask.Enabled = v2;
            MainForm.GetInstance().comboBoxRightState.Enabled = v3;
        }

        internal bool TaskFieldsValidation(TaskRequestModel task)
        {
            bool flag = false;
            if (task.Description.Trim().Length > 0 &&
                task.Priority >= 0 &&
                task.CategoryName.Trim().Length > 0) flag = true;
            return flag; 
        }

        internal TaskRequestModel GetNewTaskRequestModel()
        {
            TaskRequestModel task = null;
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                task = new()
                {
                    Description = MainForm.GetInstance().textBoxRightTask.Text,
                    Priority = MainForm.GetInstance().comboBoxRightPrior.SelectedIndex,
                    Deadline = MainForm.GetInstance().dateTimePickerRightDeadline.Value.ToString(),
                    CategoryName = MainForm.GetInstance().comboBoxRightCat.Text,
                    IsComplete = Convert.ToBoolean(MainForm.GetInstance().comboBoxRightState.SelectedIndex),
                    TagsNames = SelectNewTaskTags()
                };
            }));
            return task;
        }

        internal string GetModeType(object sender)
        {
            var rb = MainForm.GetInstance().GetCheckedRadioButton(sender);
            if (!rb.Checked) return string.Empty;

            var name = rb.Name.ToUpper();
            if (name.Contains("VIEW")) return "VIEW";
            if (name.Contains("ADD")) return "ADD";
            if (name.Contains("EDIT")) return "EDIT";
            return string.Empty;
        }

        internal void ButtonRemoveTaskTagTrigger()
        {
            MainForm.GetInstance().buttonRightRemoveTag.Enabled = MainForm.GetInstance().listBoxRightTags.SelectedIndex >= 0;
        }

        internal void PushViewRadioButton()
        {
            MainForm.GetInstance().radioButtonViewTask.Checked = true;
        }

        internal void AddCurrentTaskTag()
        {
            var cbrt = MainForm.GetInstance().comboBoxRightTags;
            var lbrt = MainForm.GetInstance().listBoxRightTags;

            if (cbrt.SelectedIndex < 0) return;

            var tagName = cbrt.Text;
            string[] currentTaskTags = new string[lbrt.Items.Count];
            for (int i = 0; i < currentTaskTags.Length; i++)
            {
                currentTaskTags[i] = lbrt.Items[i].ToString();
            }
            if (currentTaskTags.Any(i => i == tagName))
            {
                MessageBoxHelper.SendSimpleMessage($"В этой задаче метка \"{tagName}\" уже добавлена.");
                return;
            }
            lbrt.Items.Add(tagName);
            cbrt.Visible = false;
        }

        internal void RemoveTagFromTask()
        {
            var lbrt = MainForm.GetInstance().listBoxRightTags;
            var item = lbrt.SelectedItem;
            var message = $"Удалить метку \"{item}\"?";
            if (!MessageBoxHelper.SendOkCancelMessage(message)) return;
            lbrt.Items.Remove(item);
        }

        internal void PresentTagList()
        {
            var cbrt = MainForm.GetInstance().comboBoxRightTags;
            cbrt.Visible = !cbrt.Visible;
        }

        private List<string> SelectNewTaskTags()
        {
            List<string> tagsNames = new();
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                var lbrt = MainForm.GetInstance().listBoxRightTags;
                foreach (var item in lbrt.Items)
                {
                    tagsNames.Add(item.ToString());
                }
            }));
            return tagsNames;
        }

        internal void StartInit()
        {
            MainForm.GetInstance().comboBoxRightState.Items.AddRange(new string[] { "Актуальна", "Завершена" });
            MainForm.GetInstance().comboBoxRightPrior.Items.AddRange(Enum.GetNames(typeof(ThreadPriority)));
            MainForm.GetInstance().comboBoxRightTags.Visible = false;
        }

        internal void PresentAllTasks(List<TaskResponseModel> loadedTasks)
        {
            var tasks = GetFilteredTasks(loadedTasks);
            if (tasks is null) return;

            int count = 0;
            MainForm.GetInstance().Invoke(new Action(() => {
                var dgv = MainForm.GetInstance().dataGridView1;
                dgv.Rows.Clear();
                foreach (var task in tasks)
                {
                    dgv.Rows.Add(
                        ++count,
                        StringHelper.StopLengthUpToN(task.Description, 20),
                        task.Id,
                        task.Category.Name,
                        task.Priority,
                        task.Deadline,
                        task.IsComplete
                        );
                }
            }));
        }

        internal void PresentCurrentTask(TaskResponseModel currentTask)
        {
            if (currentTask is null) return;

            MainForm.GetInstance().textBoxRightTask.Text = currentTask.Description;
            MainForm.GetInstance().comboBoxRightCat.SelectedItem = currentTask.Category.Name;
            MainForm.GetInstance().comboBoxRightPrior.SelectedItem = currentTask.Priority.ToString();
            MainForm.GetInstance().dateTimePickerRightDeadline.Value = currentTask.Deadline.Value;
            MainForm.GetInstance().comboBoxRightState.SelectedIndex = Convert.ToInt32(currentTask.IsComplete);

            MainForm.GetInstance().listBoxRightTags.Items.Clear();
            if (currentTask.Tags.Count > 0)
                MainForm.GetInstance().listBoxRightTags.Items.AddRange(currentTask.Tags.Select(t => t.Name).ToArray());
        }

        internal void ClearCurrentTaskView()
        {
            MainForm.GetInstance().textBoxRightTask.Clear();
            MainForm.GetInstance().comboBoxRightCat.SelectedIndex = -1;
            MainForm.GetInstance().comboBoxRightPrior.SelectedIndex = -1;
            MainForm.GetInstance().dateTimePickerRightDeadline.Value = DateTime.Now;
            MainForm.GetInstance().comboBoxRightState.SelectedIndex = -1;
            MainForm.GetInstance().listBoxRightTags.Items?.Clear();
            MainForm.GetInstance().comboBoxRightTags.SelectedIndex = -1;
        }

        private List<TaskResponseModel> GetFilteredTasks(List<TaskResponseModel> loadedTasks)
        {
            var cbc = MainForm.GetInstance().comboBoxCategorys;
            var cbt = MainForm.GetInstance().comboBoxTags;

            if (cbc.SelectedIndex > 0 && cbt.SelectedIndex == 0)
                return loadedTasks?.Where(t => t.Category.Name == cbc.Text).ToList();

            var tagName = cbt.Text;
            if (cbc.SelectedIndex == 0 && cbt.SelectedIndex > 0)
                return loadedTasks?.Where(t => t.Tags.Any(t => t.Name == tagName)).ToList();

            if (cbc.SelectedIndex > 0 && cbt.SelectedIndex > 0)
                return loadedTasks?.
                    Where(t => t.Category.Name == cbc.Text &&
                    t.Tags.Any(t => t.Name == tagName)).ToList();

            return loadedTasks;
        }

        internal TaskResponseModel GetCurrentTask(List<TaskResponseModel> loadedTasks)
        {
            var id = GetCurrentTaskId();
            if (id == 0)
            {
                MainForm.GetInstance().radioButtonAddTask.Checked = true;
                MainForm.GetInstance().radioButtonEditTask.Enabled = false;
                MainForm.GetInstance().radioButtonViewTask.Enabled = false;
                return null;
            }
            MainForm.GetInstance().radioButtonViewTask.Checked = true;
            MainForm.GetInstance().radioButtonEditTask.Enabled = true;
            MainForm.GetInstance().radioButtonViewTask.Enabled = true;

            return loadedTasks?.FirstOrDefault(t => t.Id == id);
        }
    }
}
