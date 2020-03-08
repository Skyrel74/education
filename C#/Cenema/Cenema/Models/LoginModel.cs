using System.ComponentModel.DataAnnotations;

namespace Cenema.Models
{
    //[ModelBinder(typeof(LoginBinder))]
    public class LoginModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "Login should be 4 symbolys at least")]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}