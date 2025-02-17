using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Address.CRUD
{
    public class CreateProvinceDto
    {
        [Display(Name="نام استان")]
        [Required(ErrorMessage ="{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
