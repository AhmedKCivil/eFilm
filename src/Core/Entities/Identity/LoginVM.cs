using System.ComponentModel.DataAnnotations;

namespace Entities.Identity
{
    public class LoginVM
    {
        [Key]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
