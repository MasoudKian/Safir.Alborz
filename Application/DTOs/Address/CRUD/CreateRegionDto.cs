using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Address.CRUD
{
    public class CreateRegionDto
    {
        [Display(Name = "نام بخش")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(6)]
        public string? Code { get; set; } = string.Empty;

        [Required]
        public int ProvinceId { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    public enum CreateResult
    {
        Success, 
        Error,
        IsThere,
    }
}
