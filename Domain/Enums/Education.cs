using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum Education
    {
        [Display(Name = "زیر دیپلم")]
        Undergraduate,
        [Display(Name = "دیپلم")]
        Diploma,
        [Display(Name = "فوق دیپلم")]
        AssociateDiploma,
        [Display(Name = "لیسانس")]
        Bachelor,
        [Display(Name = "فوق لیسانس")]
        Master,
        [Display(Name ="دکترا")]
        Doctorate,

    }
}
