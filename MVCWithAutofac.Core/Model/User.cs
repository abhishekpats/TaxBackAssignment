using System.ComponentModel.DataAnnotations;

namespace MVCWithAutofac.Core.Model
{
    public class User : BaseModel<int>
    {
        public string email { get; set; }

        [Required, StringLength(100)]
        public override string Name { get; set; }
    }
}
