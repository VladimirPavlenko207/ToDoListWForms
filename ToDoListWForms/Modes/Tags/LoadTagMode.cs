using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;

namespace ToDoListWForms.Modes.Tags
{
    public class LoadTagMode : IMode
    {
        public TagRepresenter Representer { get; set; } = new();

        public void Display()
        {
            Representer.PresentLoadTagsMode();
        }

        public string Update() 
        {
            return string.Empty;
        }
    }
}
