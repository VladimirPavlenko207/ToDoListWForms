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
    public class RemoveTaskMode : IMode
    {
        public TaskRepresenter Representer { get; set; } = new();
        public void Display()
        {
           
        }

        public string Update()
        {
            var taskId = Representer.GetCurrentTaskId(); 
            if (!MessageBoxHelper.SendOkCancelMessage($"Удалить текущую задачу?")) return string.Empty;

            var url = $"{Program.Url}task/remove?id={taskId}";
            var response = RequestsSender.ClientExecuter(1, url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return $"Задача с Id = \"{taskId}\" успешно удалена.";
            }
            return response.Content;
        }
    }
}
