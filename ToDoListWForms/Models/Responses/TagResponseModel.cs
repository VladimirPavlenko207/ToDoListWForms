using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWForms.Models.Responses
{
    /// <summary>
    /// Модель получения метки
    /// </summary>
    public class TagResponseModel
    {
        /// <summary>
        /// Id метки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя метки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список задач данной метки
        /// </summary>
        public List<TaskResponseModel> Tasks { get; set; }
    }
}
