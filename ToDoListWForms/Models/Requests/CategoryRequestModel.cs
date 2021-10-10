using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWForms.Models.Requests
{
    /// <summary>
    /// Модель запросов категории
    /// </summary>
    public class CategoryRequestModel
    {
        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Новое имя категории
        /// </summary>
        public string NewName { get; set; }
    }
}
