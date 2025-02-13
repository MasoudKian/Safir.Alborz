using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Site.SiteMenu
{
    public class MenuAccess : BaseEntity
    {
        public int MenuId { get; set; } 
        public string Role { get; set; } =string.Empty;

        [ForeignKey("MenuId")]
        public Menu? Menu { get; set; }
    }
}
