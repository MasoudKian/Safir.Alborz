namespace Domain.Entities.Site
{
    public class ContactUs : BaseEntity
    {
        public string TitleImage { get; set; } = string.Empty;

        public string Map { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
