using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWForms.Models.Requests
{
    /// <summary>
    /// Модель запроса метки
    /// </summary>
    public class TagRequestModel
    {
        /// <summary>
        /// Имя метки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Новое имя метки
        /// </summary>
        public string NewName { get; set; }
    }
}
