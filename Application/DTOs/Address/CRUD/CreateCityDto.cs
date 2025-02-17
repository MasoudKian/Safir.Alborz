using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Address.CRUD
{
    public class CreateCityDto
    {
        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int ProvinceId { get; set; }
    }
}
