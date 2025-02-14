using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Site.SiteMenu
{
    public class Menu : BaseEntity
    {
        [Display(Name = "عنوان منو")]
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "آیکون")]
        public string? Icon { get; set; }

        [Display(Name = "آدرس لینک")]
        [Required, MaxLength(500)]
        public string Url { get; set; } = string.Empty;

        [Display(Name = "منوی والد")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Menu? Parent { get; set; }

        public ICollection<Menu> SubMenus { get; set; } = new List<Menu>();
        public ICollection<MenuAccess> AccessMenus { get; set; } = new List<MenuAccess>();
    }

}
