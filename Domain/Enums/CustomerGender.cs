using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CustomerGender
    {
        [Display(Name ="خانم")]
        FEMALE,
        [Display(Name = "آقا")]
        MALE,
    }
}
