using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers.Representers;

namespace ToDoListWForms.Modes.Tasks
{
    public class LoadTaskMode : IMode
    {
        public TaskRepresenter Representer { get; set; } = new();
        public void Display()
        {
            Representer.PresentLoadTaskMode();
        }

        public string Update()
        {
            return string.Empty;
        }
    }
}
