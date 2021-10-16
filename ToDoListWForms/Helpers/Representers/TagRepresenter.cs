using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListWForms.Models.Requests;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms.Helpers
{
    public class TagRepresenter 
    {
        public void PresentAllTags(List<TagResponseModel> loadedTags)
        {
            var cbt = MainForm.GetInstance().comboBoxTags;
            cbt.Items.Clear();
            cbt.Items.Add("Все метки");
            var tags = loadedTags?.Select(c => c.Name).ToArray();
            cbt.Items.AddRange(tags);
            cbt.SelectedIndex = 0;

            var cbrt = MainForm.GetInstance().comboBoxRightTags;
            cbrt.Items.Clear();
            cbrt.Items.AddRange(tags);
        }

        public string GetRemovedTagName()
        {
            var tagName = string.Empty;
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                tagName = MainForm.GetInstance().comboBoxTags.Text;
            }));
            return tagName;
        }

        public void PresentLoadTagsMode()
        {
            var cbt = MainForm.GetInstance().comboBoxTags;
            bool flag = cbt.SelectedIndex > 0;
            SetControlsState(false, true, flag, flag, true);
        }

        public void PresentAddTagsMode()
        {
            SetControlsState(true, true, false, false, false);
            MainForm.GetInstance().textBoxTag.Clear();
        }

        public void PresentEditTagsMode()
        {
            SetControlsState(true, false, false, true, false);
            MainForm.GetInstance().textBoxTag.Text = MainForm.GetInstance().comboBoxTags.Text;
        }

        private void SetControlsState(bool v1, bool v2, bool v3, bool v4, bool v5)
        {
            MainForm.GetInstance().textBoxTag.Visible = v1;
            MainForm.GetInstance().buttonAddTag.Enabled = v2;
            MainForm.GetInstance().buttonRemoveTag.Enabled = v3;
            MainForm.GetInstance().buttonEditTag.Enabled = v4;
            MainForm.GetInstance().comboBoxTags.Enabled = v5;
        }

        public TagRequestModel GetNewTagRequestModel()
        {
            var tag = new TagRequestModel();
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                tag.Name = MainForm.GetInstance().textBoxTag.Text;
            }));
            return tag;
        }

        public TagRequestModel GetTagRequestModel()
        {
            var tag = new TagRequestModel();
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                tag.Name = MainForm.GetInstance().comboBoxTags.Text;
                tag.NewName = MainForm.GetInstance().textBoxTag.Text;
            }));
            return tag;
        }

        public bool TagNameValidation(string tagName)
        {
            tagName = tagName.Trim();
            string str = string.Empty;
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                str = MainForm.GetInstance().comboBoxTags.Text;
            }));
            if (string.IsNullOrEmpty(tagName) || str == tagName)
                return false;
            return true;
        }


    }
}
