using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HumanResources.Department
{
    public class AddDepartmentDTO
    {
        [Required]
        [Display(Name ="بخش")]
        [MaxLength(300)]
        public string Name { get; set; } = string.Empty;  // نام بخش
    }

    public enum AddDepartmentResult
    {

        Success,
        Failure
    }
}
