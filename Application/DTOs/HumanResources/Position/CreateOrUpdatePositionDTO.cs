using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HumanResources.Position
{
    public class CreateOrUpdatePositionDTO
    {
        [Display(Name ="نام سمت")]
        [Required(ErrorMessage ="{0} ضروری است")]
        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }
    }
}
