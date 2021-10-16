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
    public class AddTaskMode : IMode
    {
        public TaskRepresenter Representer { get; set; } = new();
        public void Display()
        {
            Representer.PresentAddTaskMode();
        }

        public string Update()
        {
            var task = Representer.GetNewTaskRequestModel(); 
            if (!Representer.TaskFieldsValidation(task)) return "Не все поля заполнены!";
            if (!MessageBoxHelper.SendOkCancelMessage($"Вы действительно хотите создать новую задачу \"{task.Description}\"?"))
                return string.Empty;

            var url = $"{Program.Url}task/create";
            var response = RequestsSender.ClientExecuter(1, url, task);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Задача \"{task.Description}\" успешно сохранена.";
            }
            return response.Content;
        }
    }
}
