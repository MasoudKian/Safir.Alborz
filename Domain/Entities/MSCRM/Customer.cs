using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;

        public int? MarketerId { get; set; }

        [ForeignKey("MarketerId")]
        public Marketer? Marketer { get; set; }
    }
}
