using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Helpers.Representers;

namespace ToDoListWForms.Modes.Category
{
    public class EditCategoryMode : IMode
    {
        public CategoryRepresenter Representer { get; set; } = new();
        public void Display()
        {
            Representer.PresentEditCategoryMode();
        }

        public string Update()
        {
            var category = Representer.GetCategoryRequestModel();
            if (!Representer.CategoryNameValidation(category.NewName)) return string.Empty;
            if (!MessageBoxHelper.SendOkCancelMessage($"Вы действительно хотите редактировать категорию \"{category.Name}\"?"))
                return string.Empty;

            var url = $"{Program.Url}category/edit";
            var response = RequestsSender.ClientExecuter(1, url, category);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Категория \"{category.Name}\" успешно исправленна на \"{category.NewName}\".";
            }
            return response.Content;
        }
    }
}
