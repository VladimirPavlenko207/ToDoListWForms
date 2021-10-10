using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoListWForms.Models.Responses
{
    /// <summary>
    /// Модель получения задачи
    /// </summary>
    public class TaskResponseModel
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
        /// Приоритет задачи
        /// </summary>
        public ThreadPriority? Priority { get; set; }
        /// <summary>
        /// Конечная дата завершения задачи
        /// </summary>
        public DateTime? Deadline { get; set; }
        /// <summary>
        /// Завершена ли задача
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// Категория задачи
        /// </summary>
        public CategoryResponseModel Category { get; set; }
        /// <summary>
        /// Список меток данной задачи
        /// </summary>
        public List<TagResponseModel> Tags { get; set; }
    }
}
