namespace Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string? RegisteredBy { get; set; }
        public string? LastModifiedBy { get; set; }

        public DateTime RegisteredDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
