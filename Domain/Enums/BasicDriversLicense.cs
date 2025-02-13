using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum BasicDriversLicense
    {
        [Display(Name ="پایه سوم")]
        Three,
        [Display(Name = "پایه دوم")]
        Two,
        [Display(Name = "پایه یکم")]
        One
    }
}
