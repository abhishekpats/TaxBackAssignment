using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWithAutofac.Core.Model
{
    public class Comments : BaseModel<int>
    {
        [Required]
        public int TaskId { get; set; }
        public string CommentDateAdded { get; set; }
        public string TaskReminderDate { get; set; }
    }
}
