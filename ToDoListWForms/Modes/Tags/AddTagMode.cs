using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Models.Requests;

namespace ToDoListWForms.Modes.Tags
{
    public class AddTagMode : IMode
    {
        public TagRepresenter Representer { get; set; } = new();

        public void Display()
        {
            Representer.PresentAddTagsMode();
        }

        public  string Update()
        {
            var tag = Representer.GetNewTagRequestModel();
            if (!Representer.TagNameValidation(tag.Name)) return string.Empty;
            if (!MessageBoxHelper.SendOkCancelMessage($"Вы действительно хотите создать метку \"{tag.Name}\"?")) 
                return string.Empty;

            var url= $"{Program.Url}tag/create";
            var response = RequestsSender.ClientExecuter(1, url, tag);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Метка \"{tag.Name}\" успешно сохранена.";
            }
            return response.Content;
        }
    }
}
