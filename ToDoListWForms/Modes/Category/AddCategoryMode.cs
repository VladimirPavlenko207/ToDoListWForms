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
    public class AddCategoryMode : IMode
    {
        public CategoryRepresenter Representer { get; set; } = new();
        public void Display()
        {
            Representer.PresentAddCategoryMode();
        }

        public string Update()
        {
            var category = Representer.GetNewCategoryRequestModel();
            if (!Representer.CategoryNameValidation(category.Name)) return string.Empty;
            if (!MessageBoxHelper.SendOkCancelMessage($"Вы действительно хотите создать категорию \"{category.Name}\"?"))
                return string.Empty;

            var url = $"{Program.Url}category/create";
            var response = RequestsSender.ClientExecuter(1, url, category);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Категория \"{category.Name}\" успешно сохранена.";
            }
            return response.Content;
        }
    }
}
