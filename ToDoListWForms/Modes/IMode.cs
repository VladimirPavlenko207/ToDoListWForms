using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;

namespace ToDoListWForms.Modes
{
    public interface IMode
    {
        string Update(); 
        void Display();
    }
}
