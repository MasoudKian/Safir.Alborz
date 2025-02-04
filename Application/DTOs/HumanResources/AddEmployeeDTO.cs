using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HumanResources
{
    public class AddEmployeeDTO
    {

        [Display(Name = "نام")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "نام خانوادگی")]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "کد ملی")]
        [Required]
        public string IRCode { get; set; } = string.Empty;

        [Display(Name = "شماره شناسنامه")]
        [Required]
        public string BirthCertificateNumber { get; set; } = string.Empty;

        [Display(Name = "شماره تماس")]
        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Display(Name = "ایمیل")]
        [Required]
        public string? Email { get; set; }

        [Display(Name = "آدرس محل سکونت")]
        [Required]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "شناسه")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Display(Name = "مقطع تحصیلی")]
        [Required]
        public Education Education { get; set; }

        [Display(Name = "رشته تحصیلی")]
        [Required]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Display(Name = "تاریخ استخدام")]
        [Required]
        public string DateOfEmployment { get; set; } = string.Empty;


        [Display(Name = "شماره تماس فامیل درجه 1")]
        [Required]
        public string FamiliarPhone { get; set; } = string.Empty;

        [Display(Name = "رمز عبور")]
        [Required]
        public string Password { get; set; } = string.Empty;


    }
    public enum AddEmployeeResult
    {
        Success,
        ThereIs,
        Warning,
        Error
    }
}
