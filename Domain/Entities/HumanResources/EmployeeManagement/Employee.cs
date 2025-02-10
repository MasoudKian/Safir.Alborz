using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HumanResources.EmployeeManagement
{

    public class Employee : BaseEntity
    {
        [Display(Name = "نام")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "کد ملی")]
        public string IRCode { get; set; } = string.Empty;

        [Display(Name = "شماره شناسنامه")]
        public string BirthCertificateNumber { get; set; } = string.Empty;

        [Display(Name = "شماره تماس")]
        public string Mobile { get; set; } = string.Empty;

        [Display(Name = "ایمیل")]
        public string? Email { get; set; }

        [Display(Name = "آدرس محل سکونت")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "شناسه")]
        public string EmployeeID { get; set; } = string.Empty;

        [Display(Name = "مقطع تحصیلی")]
        public Education Education { get; set; }

        [Display(Name = "رشته تحصیلی")]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Display(Name = "تاریخ استخدام")]
        public DateTime? DateOfEmployment { get; set; }

        [Display(Name = "تاریخ خروج")]
        public DateTime? DateOfExit { get; set; }

        [Display(Name = "شماره تماس فامیل درجه 1")]
        public string FamiliarPhone { get; set; } = string.Empty;


        #region Relation

        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }

        public Position? Position { get; set; }
        public int? PositionId { get; set; }

        #endregion

    }
}
