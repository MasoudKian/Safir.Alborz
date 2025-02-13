using Domain.Entities.Address;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Driver : BaseEntity
    {
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Display(Name = "شماره گواهینامه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(10)]
        public string LicenseNumber { get; set; } = string.Empty;

        [Display(Name = "پایه گواهینامه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public BasicDriversLicense BasicDriversLicense { get; set; }

        [Display(Name = "تاریخ صدور")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public string DateOfIssue { get; set; } = string.Empty;

        [Display(Name = "مدت اعتبار")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public int ValidityPeriod { get; set; }

        [Display(Name = "نوع وسیله نقلیه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(50)]
        public string VehicleType { get; set; } = string.Empty;

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}
