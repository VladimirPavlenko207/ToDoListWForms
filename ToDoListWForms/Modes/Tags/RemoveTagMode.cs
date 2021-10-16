using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;

namespace ToDoListWForms.Modes.Tags
{
    public class RemoveTagMode : IMode
    {
        public TagRepresenter Representer { get; set; } = new();

        public void Display()
        {
            
        }

        public string Update()
        {
            var tagName = Representer.GetRemovedTagName();
            if (!MessageBoxHelper.SendOkCancelMessage($"Удалить метку \"{tagName}\"?")) return string.Empty;

            var url = $"{Program.Url}tag/remove?name={tagName}";
            var response = RequestsSender.ClientExecuter(1, url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Метка \"{tagName}\" успешно удалена.";
            }
            return response.Content;
        }
    }
}
