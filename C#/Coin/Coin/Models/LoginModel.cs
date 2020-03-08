using System.ComponentModel.DataAnnotations;

namespace Coin.Models
{
    public class LoginModel
    {
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(8, ErrorMessage = "Login should be 8 symbolys at least")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
         ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password should be 8 symbolys at least")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}