using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Clue : BaseEntity
    {
        [Display(Name ="نام سرنخ")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(300)]
        public string ClueName { get; set; } = string.Empty;

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "اطلاعات سر نخ")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(500)]
        public string ContactInfo { get; set; } = string.Empty;

        [Display(Name = "اطلاعات سر نخ")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(6)]
        public string ClueCode { get; set; } = string.Empty;

        [Display(Name = "تبدیل شد / تبدیل نشد")]
        public bool IsConverted { get; set; } // آیا این سرنخ به مشتری تبدیل شده؟

        public int MarketerId { get; set; }

        [ForeignKey("MarketerId")]
        public Marketer? Marketer { get; set; }


    }
}
