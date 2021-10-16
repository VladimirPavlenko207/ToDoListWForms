using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Helpers.Representers;

namespace ToDoListWForms.Modes.Tasks
{
    public class EditTaskMode : IMode
    {
        public TaskRepresenter Representer { get; set; } = new();
        public void Display()
        {
            Representer.PresentEditTaskMode();
        }

        public string Update()
        {
            var task = Representer.GetNewTaskRequestModel();
            task.Id = Representer.GetCurrentTaskId();
            if (!Representer.TaskFieldsValidation(task)) return "Не все поля заполнены!";
            if (!MessageBoxHelper.SendOkCancelMessage($"Вы действительно хотите сохранить задачу \"{task.Description}\"?"))
                return string.Empty;

            var url = $"{Program.Url}task/edit";
            var response = RequestsSender.ClientExecuter(1, url, task);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Изменения в задаче \"{task.Description}\" прошли успешно.";
            }
            return response.Content;
        }
    }
}
