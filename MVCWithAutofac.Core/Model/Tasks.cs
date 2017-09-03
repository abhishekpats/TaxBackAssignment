using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVCWithAutofac.Core.Model
{
    public class Tasks : BaseModel<int>
    {
        [Required]
        public int TaskStatusId { get; set; }
        [Required]
        public int TaskTypeId { get; set; }
        [Required]
        public int TaskAssignedTo { get; set; }
        [Required]
        public string TaskDateCreated { get; set; }
        public string TaskNextActionDate { get; set; }
    }
}
