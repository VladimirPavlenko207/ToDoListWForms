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
    /// <summary>
    /// Работа с метками
    /// </summary>
    public partial class MainForm : Form
    {
        private Operations tagMode;

        private List<TagResponseModel> LoadedTags { get; set; } 
        private string TagUrl { get; set; }
        private string CurrentTagName { get; set; }

        private Operations TagMode
        { 
            get => tagMode;
            set => SelectTagMode(value);
        }

        private void SelectTagMode(Operations value)
        {
            TagUrl= $"{Program.Url}tag";
            tagMode = value;
            switch (value)
            {
                case Operations.Add:
                    SetTagOperation(true, true, false, false, false);
                    TagUrl += "/create";
                    break;
                case Operations.Edit:
                    SetTagOperation(true, false, false, true, false);
                    TagUrl += "/edit";
                    break;
                case Operations.None:
                    bool flag = comboBoxTags.SelectedIndex > 0;
                    SetTagOperation(false, true, flag, flag, true);
                    break;
                case Operations.Remove:
                    TagUrl += "/remove?name=";
                    break;
            }
        }

        private void SetTagOperation(bool v1, bool v2, bool v3, bool v4, bool v5)
        {
            textBoxTag.Visible = v1;
            buttonAddTag.Enabled = v2;
            buttonDeleteTag.Enabled = v3;
            buttonEditTag.Enabled = v4;
            comboBoxTags.Enabled = v5;
        }

        private async Task<bool> LoadTagsAsync()
        {
            TagMode = Operations.None;
            var response = await Task.Run(() => RequestsSender.ClientExecuter(0, TagUrl));
            if (response.StatusCode == 0) return false;
            
            LoadedTags = RequestsSender.GetDeserializedObject(LoadedTags, response.Content);

            comboBoxTags.Items.Clear();
            comboBoxTags.Items.Add("Все метки");
            comboBoxTags.Items.AddRange(LoadedTags.Select(c => c.Name).ToArray());
            comboBoxTags.SelectedIndex = 0;
            
            comboBoxRightTags.Items.Clear();
            comboBoxRightTags.Items.AddRange(LoadedTags.Select(c => c.Name).ToArray());

            if (!isBootStrap)
                _ = LoadTasksAsync();
            return true;
        }

        private void comboBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsTag();
            CurrentTagName = comboBoxTags.SelectedIndex > 0 ? comboBoxTags.Text : string.Empty;
            DisplayAllTasks();
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            TagMode = TagMode == Operations.Add ?
               Operations.None : Operations.Add;
            textBoxTag.Clear();
        }

        private void buttonDeleteTag_Click(object sender, EventArgs e)
        {
            RemoveTagAsync();
        }

        private void buttonEditTag_Click(object sender, EventArgs e)
        {
            TagMode = TagMode == Operations.Edit ?
              Operations.None : Operations.Edit;
            textBoxTag.Text = comboBoxTags.Text;
        }

        private void textBoxTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                var newName = (sender as TextBox).Text.Trim();
                if (string.IsNullOrEmpty(newName) || newName == CurrentTagName) return;

                string mes;
                switch (TagMode)
                {
                    case Operations.Add:
                        mes = $"Вы действительно хотите создать метку \"{newName}\"?";
                        if (MessageBox.Show(mes, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            _ = CreateNewTagAsync();
                        break;
                    case Operations.Edit:
                        mes = $"Вы действительно хотите редактировать метку \"{comboBoxTags.Text}\"?";
                        if (MessageBox.Show(mes, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            _ = EditTagAsync();
                        break;
                }
            }
        }

        private async Task EditTagAsync()
        {
            TagMode = Operations.Edit;
            var tag = new TagRequestModel()
            {
                Name = comboBoxTags.Text,
                NewName = textBoxTag.Text
            };
            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, TagUrl, tag));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await LoadTagsAsync();
                MessageBox.Show($"Категория \"{tag.Name}\" успешно исправленна на \"{tag.NewName}\".");
            }
            else MessageBox.Show(response.Content);
        }

        private void SetButtonsTag() 
        {
            buttonDeleteTag.Enabled = buttonEditTag.Enabled = comboBoxTags.SelectedIndex > 0;
        }

        private async Task CreateNewTagAsync() 
        {
            if (string.IsNullOrEmpty(textBoxTag.Text)) return;

            var newTag = new TagRequestModel() { Name = textBoxTag.Text };
            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, TagUrl, newTag));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await LoadTagsAsync();
                MessageBox.Show($"Метка \"{newTag.Name}\" успешно сохранена.");
            }
            else MessageBox.Show(response.Content);
        }

        private async void RemoveTagAsync() 
        {
            var mess = $"Удалить метку \"{comboBoxTags.Text}\"?";
            if (MessageBox.Show(mess, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            TagMode = Operations.Remove;

            var name = comboBoxTags.Text;
            var response = await Task.Run(() => RequestsSender.ClientExecuter(1, TagUrl + name));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await LoadTagsAsync(); 
                MessageBox.Show($"Метка \"{name}\" успешно удалена.");
            }
            else MessageBox.Show(response.Content);
        }
    }
}
