using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWithAutofac.Core.Model
{
    public class TaskType : BaseModel<int>
    {
        [Required, StringLength(100)]
        public override string Name { get; set; }
    }
}
