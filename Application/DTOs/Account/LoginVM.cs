using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Account
{
    public class LoginVM
    {

        [Required(ErrorMessage = "لطفاً نام کاربری یا ایمیل خود را وارد کنید.")]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} خود را وارد نمایید.")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "یادآوری")]
        public bool RemeberMe { get; set; }
    }
}
