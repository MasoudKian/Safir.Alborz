using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HumanResources.EmployeeManagement
{

    public class Employee : BaseEntity
    {
        [Display(Name = "نام")]
        [MaxLength(500)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "نام خانوادگی")]
        [MaxLength(500)]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "آواتار")]
        public string ImageAddress { get; set; } = string.Empty;

        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        public string IRCode { get; set; } = string.Empty;


        [Display(Name = "شماره شناسنامه")]
        [MaxLength(50)]
        public string BirthCertificateNumber { get; set; } = string.Empty;

        [Display(Name = "تاریخ تولد")]
        [MaxLength(20)]
        public string BirthDate { get; set; } = string.Empty;

        [Display(Name = "شماره تماس")]
        [MaxLength(11)]
        public string Mobile { get; set; } = string.Empty;

        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        public string? Email { get; set; }

        [Display(Name = "آدرس محل سکونت")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "شناسه")]
        [MaxLength(10)]
        public string EmployeeID { get; set; } = string.Empty;

        [Display(Name = "مقطع تحصیلی")]
        public Education Education { get; set; }

        [Display(Name = "رشته تحصیلی")]
        [MaxLength(200)]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Display(Name = "تاریخ استخدام")]
        public DateTime? DateOfEmployment { get; set; }

        [Display(Name = "تاریخ خروج")]
        public DateTime? DateOfExit { get; set; }

        [Display(Name = "شماره تماس فامیل درجه 1")]
        [MaxLength(11)]
        public string FamiliarPhone { get; set; } = string.Empty;


        #region Relation

        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }

        public Position? Position { get; set; }
        public int? PositionId { get; set; }

        #endregion

    }


}
