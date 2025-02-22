using Domain.Entities.Address;
using Domain.Entities.MSCRM;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.OredersANDinvoices
{
    public class Order : BaseEntity
    {
        [Display(Name = "کد سفارش")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(10)]
        public string OrderCode { get; set; } = string.Empty;

        [Display(Name = "تاریخ سفارش")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "وضعیت سفارش")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public OrderStatus OrderStatus { get; set; } // (مثلاً: در انتظار، در حال ارسال، تحویل شده)

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int MarketerId { get; set; }
        [ForeignKey("MarketerId")]
        public Marketer Marketer { get; set; }

        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}
