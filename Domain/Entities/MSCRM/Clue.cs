using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Clue : BaseEntity
    {
        public string ClueName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string ClueCode { get; set; } = string.Empty;

        public int MarketerId { get; set; }

        [ForeignKey("MarketerId")]
        public Marketer? Marketer { get; set; }

        public bool IsConverted { get; set; } // آیا این سرنخ به مشتری تبدیل شده؟
    }
}
