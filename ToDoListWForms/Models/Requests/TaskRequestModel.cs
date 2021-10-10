using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms.Models.Requests
{
    /// <summary>
    /// Модель запроса задачи
    /// </summary>
    public class TaskRequestModel
    {
        /// <summary>
        /// Id задачи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Приоритет задачи выраженное целым числом из <see cref="ThreadPriority"/>
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Строковое представление конечной даты  
        /// </summary>
        public string Deadline { get; set; }
        /// <summary>
        /// Логическое значение завершенности задачи
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// Имя категории задачи
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Список имен меток для задачи
        /// </summary>
        public List<string> TagsNames { get; set; } 
    }
}
