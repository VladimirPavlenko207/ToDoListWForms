using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoListWForms.Models.Responses
{
    public class TaskResponseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ThreadPriority? Priority { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsComplete { get; set; }
        public CategoryResponseModel Category { get; set; }
        public List<TagResponseModel> Tags { get; set; }
    }
}
