using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string? RegisteredBy { get; set; }

        [MaxLength(500)]
        public string? LastModifiedBy { get; set; }

        public DateTime RegisteredDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
