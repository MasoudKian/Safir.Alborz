using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.IdentityAccount.Role
{
    public class EditRoleDTO
    {
        public string RoleId { get; set; } = string.Empty;

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(256, ErrorMessage = "{0} نباید بیشتر از {1} باشد.")]
        public string RoleName { get; set; } = string.Empty;

        [Display(Name = "توضیحات نقش")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(500, ErrorMessage = "{0} نباید بیشتر از {1} باشد.")]
        public string Description { get; set; } = string.Empty;
    }
}
