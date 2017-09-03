using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWithAutofac.Core.Model;

namespace MVCWithAutofac.Web.Models
{
    public class TaskModel
    {
        public Tasks Task { get; set; }
        public List<TaskStatus> Status { get; set; }
        public List<TaskType> TaskType { get; set; }
        public List<User> Users { get; set; }
        public int UserId { get; set; }
    }
}