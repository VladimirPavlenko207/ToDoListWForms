using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Models.Requests;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms.Helpers.Representers
{
    public class CategoryRepresenter
    {
        public void PresentAllCategories(List<CategoryResponseModel> loadedCategories)
        {
            var cbc = MainForm.GetInstance().comboBoxCategorys;
            cbc.Items.Clear();
            cbc.Items.Add("Все категории");
            var categories = loadedCategories?.Select(c => c.Name).ToArray();
            cbc.Items.AddRange(categories);
            cbc.SelectedIndex = 0;

            var cbrt = MainForm.GetInstance().comboBoxRightCat;
            cbrt.Items.Clear();
            cbrt.Items.AddRange(categories);
        }

        public string GetRemovedCategoryName()
        {
            var categoryName = string.Empty;
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                categoryName = MainForm.GetInstance().comboBoxCategorys.Text;
            }));
            return categoryName;
        }

        public CategoryRequestModel GetCategoryRequestModel()
        {
            var category = new CategoryRequestModel();
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                category.Name = MainForm.GetInstance().comboBoxCategorys.Text;
                category.NewName = MainForm.GetInstance().textBoxCategory.Text;
            }));
            return category;
        }

        public void PresentEditCategoryMode()
        {
            SetControlsState(true, false, false, true, false);
            MainForm.GetInstance().textBoxCategory.Text = MainForm.GetInstance().comboBoxCategorys.Text;
        }

        public void PresentLoadCategoryMode()
        {
            var cbc = MainForm.GetInstance().comboBoxCategorys;
            bool flag = cbc.SelectedIndex > 0;
            SetControlsState(false, true, flag, flag, true);
        }

        public bool CategoryNameValidation(string categoryName)
        {
            categoryName = categoryName.Trim();
            string str = string.Empty;
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                str = MainForm.GetInstance().comboBoxCategorys.Text;
            }));
            if (string.IsNullOrEmpty(categoryName) || str == categoryName)
                return false;
            return true;
        }

        public CategoryRequestModel GetNewCategoryRequestModel()
        {
            var category = new CategoryRequestModel();
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                category.Name = MainForm.GetInstance().textBoxCategory.Text;
            }));
            return category;
        }

        public void PresentAddCategoryMode()
        {
            SetControlsState(true, true, false, false, false);
            MainForm.GetInstance().textBoxCategory.Clear();
        }

        private void SetControlsState(bool v1, bool v2, bool v3, bool v4, bool v5)
        {
            MainForm.GetInstance().textBoxCategory.Visible = v1;
            MainForm.GetInstance().buttonAddCategory.Enabled = v2;
            MainForm.GetInstance().buttonRemoveCategory.Enabled = v3;
            MainForm.GetInstance().buttonEditCategory.Enabled = v4;
            MainForm.GetInstance().comboBoxCategorys.Enabled = v5;
        }
    }
}
