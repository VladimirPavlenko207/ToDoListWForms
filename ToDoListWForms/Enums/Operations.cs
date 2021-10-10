using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWForms.Enums
{
    /// <summary>
    /// Определяет вид операции
    /// </summary>
    public enum Operations
    {
        /// <summary>
        /// Операция добавления
        /// </summary>
        Add,
        /// <summary>
        /// Операция редактирования
        /// </summary>
        Edit,
        /// <summary>
        /// Операция удаления
        /// </summary>
        Remove,
        /// <summary>
        /// Операция бездействия
        /// </summary>
        None
    }
}
