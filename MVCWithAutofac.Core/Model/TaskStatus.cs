using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVCWithAutofac.Core.Model
{
    public class TaskStatus : BaseModel<int>
    {
        [Required, StringLength(100)]
        public override string Name { get; set; }
    }
}
