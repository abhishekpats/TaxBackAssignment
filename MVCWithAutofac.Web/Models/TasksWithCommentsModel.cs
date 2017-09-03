using MVCWithAutofac.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithAutofac.Web.Models
{
    public class TasksWithCommentsModel
    {
        public Tasks Task { get; set; }
        public List<TaskStatus> Status { get; set; }
        public List<TaskType> TaskType { get; set; }
        public List<User> Users { get; set; }
        public List<Comments> Comments { get; set; }
        public Comments Comment { get; set; }
    }
}