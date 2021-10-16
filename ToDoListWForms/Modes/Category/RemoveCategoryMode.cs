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
    public class RemoveCategoryMode : IMode
    {
        public CategoryRepresenter Representer { get; set; } = new();
        public void Display()
        {
           
        }

        public string Update()
        {
            var categoryName = Representer.GetRemovedCategoryName();
            if (!MessageBoxHelper.SendOkCancelMessage($"Удалить категорию \"{categoryName}\"?")) return string.Empty;

            var url = $"{Program.Url}category/remove?name={categoryName}";
            var response = RequestsSender.ClientExecuter(1, url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Категория \"{categoryName}\" успешно удалена.";
            }
            return response.Content;
        }
    }
}
