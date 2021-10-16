using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;

namespace ToDoListWForms.Modes.Tags
{
    public class EditTagMode : IMode
    {
        public TagRepresenter Representer { get; set; } = new();

        public void Display()
        {
            Representer.PresentEditTagsMode();
        }

        public string Update()
        {
            var tag = Representer.GetTagRequestModel();
            if (!Representer.TagNameValidation(tag.NewName)) return string.Empty;
            if (!MessageBoxHelper.SendOkCancelMessage($"Вы действительно хотите редактировать метку \"{tag.Name}\"?")) 
                return string.Empty;

            var url = $"{Program.Url}tag/edit";
            var response = RequestsSender.ClientExecuter(1, url, tag);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Метка \"{tag.Name}\" успешно исправленна на \"{tag.NewName}\".";
            }
            return response.Content;
        }
    }
}
