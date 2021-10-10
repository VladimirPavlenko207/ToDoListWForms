using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoListWForms.Models.Responses;

namespace ToDoListWForms.Models.Requests
{
    public class TaskRequestModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Deadline { get; set; }
        public bool IsComplete { get; set; }
        public string CategoryName { get; set; }
        public List<string> TagsNames { get; set; } 
    }
}
