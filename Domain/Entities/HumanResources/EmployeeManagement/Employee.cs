using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Domain.Entities.HumanResources.EmployeeManagement
{

    public class Employee : BaseEntity
    {
        // Relation for ApplicationUser
        public string UserId { get; set; } = string.Empty;


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
        public string DateOfEmployment { get; set; } = string.Empty;

        [Display(Name = "تاریخ خروج")]
        public string DateOfExit { get; set; } = string.Empty;

        [Display(Name = "شماره تماس فامیل درجه 1")]
        public string FamiliarPhone { get; set; } = string.Empty;

    }
}
