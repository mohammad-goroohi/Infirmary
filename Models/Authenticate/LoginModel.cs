using System.ComponentModel.DataAnnotations;
namespace Infirmary.Models.Authenticate
{
    public class LoginModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [MinLength(3, ErrorMessage = "نام کاربری حداقل باید ۳ کاراکتر باشد")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [MinLength(6, ErrorMessage = "رمز عبور حداقل باید ۶ کاراکتر باشد")]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }

}
