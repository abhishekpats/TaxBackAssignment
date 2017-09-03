using MVCWithAutofac.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithAutofac.Web.Models
{
    public class ListTasks
    {
        public List<Tasks> Tasks { get; set; }
        public List<TaskStatus> Status { get; set; }
        public List<TaskType> TaskType { get; set; }
        public List<User> Users { get; set; }
        public List<Comments> Comments { get; set; }
        public string searchText { get; set; }
    }
}