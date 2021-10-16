using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Models.Responses;
using ToDoListWForms.Modes;
using ToDoListWForms.Modes.Tags;

namespace ToDoListWForms.Controllers
{
    /// <summary>
    /// Контроллер метки
    /// </summary>
    public class TagController : BaseController
    {
        private TagRepresenter _representer;
        private List<TagResponseModel> LoadedTags { get; set; }

        public TagController()
        {
            _representer = new();
            SetLoadMode();
        }

        public override async Task<bool> LoadAsync()
        {
            var tagUrl = $"{Program.Url}tag";
            var response = await Task.Run(() => RequestsSender.ClientExecuter(0, tagUrl));

            LoadedTags = RequestsSender.GetDeserializedObject(LoadedTags, response.Content);
            if (LoadedTags is null) return false;

            _representer.PresentAllTags(LoadedTags);
            return true;
        }

        public override void Display()
        {
            Mode?.Display();
        }

        public override void AddModeTrigger()
        {
            Mode = Mode is AddTagMode ? new LoadTagMode() : new AddTagMode();
        }

        public override void EditModeTrigger()
        {
            Mode = Mode is EditTagMode ? new LoadTagMode() : new EditTagMode();
        }

        public override void SetAddMode()
        {
            Mode = new AddTagMode();
        }

        public override void SetEditMode()
        {
            Mode = new EditTagMode();
        }

        public override void SetRemoveMode()
        {
            Mode = new RemoveTagMode();
        }

        public override async Task<string> UpdateAsync()
        {
            return await Task.Run(() => Mode.Update());
        }

        public override void SetLoadMode()
        {
            Mode = new LoadTagMode();
        }

        protected override void SetVirtualLoadMode()
        {
            SetLoadMode();
        }
    }
}
