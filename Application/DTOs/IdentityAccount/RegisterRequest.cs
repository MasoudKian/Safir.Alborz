using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.IdentityAccount
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(20, ErrorMessage = "نام کاربری باید حداکثر از 20 حرف باشد")]
        [MinLength(6, ErrorMessage = "نام کاربری باید حداقل 6 کاراکتر باشد")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "رمز عبور")]
        [MinLength(8)]
        [MaxLength(8)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تکرار رمز عبور")]
        [MinLength(8)]
        [MaxLength(8)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن مطابقت ندارند")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
