using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.IdentityAccount
{
    public class AuthLoginRequest
    {
        [Required(ErrorMessage = "لطفاً نام کاربری یا ایمیل خود را وارد کنید.")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} خود را وارد نمایید.")]
        public string Password { get; set; } = string.Empty;

        public bool  RememberMe { get; set; }

    }
}
