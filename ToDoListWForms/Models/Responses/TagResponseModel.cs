using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWForms.Models.Responses
{
    public class TagResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskResponseModel> Tasks { get; set; }
    }
}
