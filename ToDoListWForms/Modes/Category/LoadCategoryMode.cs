using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Helpers.Representers;

namespace ToDoListWForms.Modes.Category
{
    public class LoadCategoryMode : IMode
    {
        public CategoryRepresenter Representer { get; set; } = new();

        public void Display()
        {
            Representer.PresentLoadCategoryMode();
        }

        public string Update()
        {
            return string.Empty;
        }
    }
}
