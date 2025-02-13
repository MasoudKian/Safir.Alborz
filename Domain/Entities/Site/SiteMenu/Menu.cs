namespace Domain.Entities.Site.SiteMenu
{
    public class Menu : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Url { get; set; }
        public string Icon { get; set; } = string.Empty;
        public int? ParentId { get; set; } // در صورتی که زیرمنو باشه، به منوی اصلی متصل میشه
        public Menu? Parent { get; set; }
        public ICollection<Menu> Children { get; set; } = new List<Menu>();
    }
}
