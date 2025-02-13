using Domain.Entities.Address;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Customer : BaseEntity
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(300)]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(11)]
        [Phone(ErrorMessage = "شماره {0} معتبر نیست.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(300)]
        public string StoreName { get; set; } = string.Empty;

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "کد مشتری")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(6)]
        public string CustomerCode { get; set; } = string.Empty;

        public CustomerGender CustomerGender { get; set; }

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public int? MarketerId { get; set; }
        [ForeignKey("MarketerId")]
        public Marketer? Marketer { get; set; }
    }
}
