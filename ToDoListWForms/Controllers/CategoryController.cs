using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Helpers.Representers;
using ToDoListWForms.Models.Responses;
using ToDoListWForms.Modes.Category;

namespace ToDoListWForms.Controllers
{
    public class CategoryController : BaseController
    {
        private CategoryRepresenter _representer;
        private List<CategoryResponseModel> LoadedCategories { get; set; } 
        public CategoryController()
        {
            _representer = new();
            SetLoadMode();
        }
        public override void AddModeTrigger()
        {
            Mode = Mode is AddCategoryMode ? new LoadCategoryMode() : new AddCategoryMode();
        }

        public override void Display()
        {
            Mode?.Display();
        }

        public override void EditModeTrigger()
        {
            Mode = Mode is EditCategoryMode ? new LoadCategoryMode() : new EditCategoryMode();
        }

        public override async Task<bool> LoadAsync()
        {
            var url = $"{Program.Url}category";
            var response = await Task.Run(() => RequestsSender.ClientExecuter(0, url));

            LoadedCategories = RequestsSender.GetDeserializedObject(LoadedCategories, response.Content);
            if (LoadedCategories is null) return false;

            _representer.PresentAllCategories(LoadedCategories);
            return true;
        }

        public override void SetAddMode()
        {
            Mode = new AddCategoryMode();
        }

        public override void SetEditMode()
        {
            Mode = new EditCategoryMode();
        }

        public override void SetLoadMode()
        {
            Mode = new LoadCategoryMode();
        }

        public override void SetRemoveMode()
        {
            Mode = new RemoveCategoryMode();
        }

        public override async Task<string> UpdateAsync()
        {
            return await Task.Run(() => Mode.Update());
        }

        protected override void SetVirtualLoadMode()
        {
            SetLoadMode();
        }
    }
}
