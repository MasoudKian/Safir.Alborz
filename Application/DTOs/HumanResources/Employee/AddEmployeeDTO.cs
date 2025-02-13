using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.DTOs.HumanResources.Employee
{
    public class AddEmployeeDTO
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} باید بین 2 تا 50 کاراکتر باشد.")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} باید بین 2 تا 50 کاراکتر باشد.")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید دقیقا 10 رقم باشد.")]
        public string IRCode { get; set; } = string.Empty;

        [Display(Name = "تاریخ تولد")]
        [MaxLength(20, ErrorMessage = "{0} نباید بیشتر از 20 کاراکتر باشد.")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public string BirthDate { get; set; } = string.Empty;

        [Display(Name = "شماره شناسنامه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "شماره شناسنامه باید فقط شامل اعداد باشد.")]
        public string BirthCertificateNumber { get; set; } = string.Empty;

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل باید با 09 شروع شده و 11 رقم باشد.")]
        public string Mobile { get; set; } = string.Empty;

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
        public string? Email { get; set; }

        [Display(Name = "آدرس محل سکونت")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [StringLength(250, ErrorMessage = "{0} نباید بیشتر از 250 کاراکتر باشد.")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "شناسه")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Display(Name = "عکس پروفایل")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public IFormFile? ProfileImage { get; set; }


        [Display(Name = "مقطع تحصیلی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public Education Education { get; set; }

        [Display(Name = "رشته تحصیلی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Display(Name = "تاریخ استخدام")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public DateTime DateOfEmployment { get; set; }

        [Display(Name = "شماره تماس فامیل درجه 1")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تماس فامیل باید با 09 شروع شده و 11 رقم باشد.")]
        public string FamiliarPhone { get; set; } = string.Empty;

        [Display(Name = "رمز عبور")]
        [MinLength(8)]
        [MaxLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "رمز عبور باید شامل حداقل یک حرف کوچک، یک حرف بزرگ، یک عدد و یک کاراکتر خاص باشد.")]
        public string Password { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }

    public enum AddEmployeeResult
    {
        Success,
        ThereIs,
        Warning,
        Error,
        DepartmentNotFound
    }


}
