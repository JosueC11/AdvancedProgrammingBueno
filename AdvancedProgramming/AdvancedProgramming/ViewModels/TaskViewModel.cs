using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedProgramming.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public string CreatedAt { get; set; }
    }
}