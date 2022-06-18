using System.ComponentModel.DataAnnotations;

namespace Cosmetic_Store.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "User Name")]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
