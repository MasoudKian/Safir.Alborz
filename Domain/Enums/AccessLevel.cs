using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum AccessLevel
    {
        [Display(Name = "ثبت")]
        Create,
        [Display(Name = "خواندن")]
        Read,
        [Display(Name = "ویرایش")]
        Update,
        [Display(Name = "حذف")]
        Delete
    }
}
