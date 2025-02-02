using System.ComponentModel.DataAnnotations;

namespace Application.Models.AuthenticationIdentity
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "نام کاربری باید حداقل 6 کاراکتر باشد.")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(8, ErrorMessage = "حداقل تعداد کاراکتر مجاز رمزعبور 8 می باشد.")]
        public string Password { get; set; } = string.Empty;
    }
}
