using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Helpers.Representers;
using ToDoListWForms.Models.Responses;
using ToDoListWForms.Modes.Tasks;

namespace ToDoListWForms.Controllers
{
    public class TaskController : BaseController
    {
        private TaskRepresenter _representer;
        private bool _isStart = true;
        private List<TaskResponseModel> LoadedTasks { get; set; }
        private TaskResponseModel CurrentTask { get; set; }
        public TaskController()
        {
            _representer = new();
            SetLoadMode();
        }
        public override void AddModeTrigger()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
           
            Mode?.Display();
            var ct = Mode is AddTaskMode ? null : CurrentTask;
            _representer.PresentCurrentTask(ct);
        }

        public override void EditModeTrigger()
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> LoadAsync()
        {
            if (_isStart)
            {
                _representer.StartInit();
                _isStart = false;
            }
            var url = $"{Program.Url}Task";
            var response = await Task.Run(() => RequestsSender.ClientExecuter(0, url));

            LoadedTasks = RequestsSender.GetDeserializedObject(LoadedTasks, response.Content);
            if (LoadedTasks is null) return false;

            _representer.PresentAllTasks(LoadedTasks);
            return true;
        }

        public override void SetAddMode()
        {
            Mode = new AddTaskMode();
        }

        public override void SetEditMode()
        {
            Mode = new EditTaskMode();
        }

        public override void SetLoadMode()
        {
            Mode = new LoadTaskMode();
        }

        public override void SetRemoveMode()
        {
            Mode = new RemoveTaskMode();
        }

        public override async Task<string> UpdateAsync()
        {
            return await Task.Run(() => Mode.Update());
        }

        public void DisplayAllTasks()
        {
            _representer.PresentAllTasks(LoadedTasks);
        }

        public void GetCurrentTask()
        {
            CurrentTask = _representer.GetCurrentTask(LoadedTasks);
           
        }

        internal void ShowTagList()
        {
            _representer.PresentTagList();
        }

        internal void RemoveTagFromTask()
        {
            _representer.RemoveTagFromTask();
        }

        internal void RadioButtonsTrigger(object sender)
        {
            string modeType = _representer.GetModeType(sender);
            switch (modeType)
            {
                case "VIEW":
                    SetLoadMode();
                    break;
                case "ADD":
                    SetAddMode();
                    break;
                case "EDIT":
                    SetEditMode();
                    break;
            }
        }

        protected override void SetVirtualLoadMode()
        {
            _representer.PushViewRadioButton();
        }

        internal void ButtonRemoveTaskTagTrigger()
        {
            if (Mode is AddTaskMode || Mode is EditTaskMode)
                _representer.ButtonRemoveTaskTagTrigger();
        }

        internal void AddCurrentTaskTag()
        {
            _representer.AddCurrentTaskTag();
            
        }
    }
}
