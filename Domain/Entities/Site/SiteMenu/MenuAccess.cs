using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Site.SiteMenu
{
    public class MenuAccess : BaseEntity
    {
        public string Role { get; set; } =string.Empty;

        public int MenuId { get; set; } 

        [ForeignKey("MenuId")]
        public Menu? Menu { get; set; }

        // اضافه کردن سطح دسترسی
        [Display(Name = "سطح دسترسی")]
        public AccessLevel AccessLevel { get; set; }
        // create , read , update, delete
    }


}
