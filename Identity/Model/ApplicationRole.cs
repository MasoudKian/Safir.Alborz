using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class ApplicationRole : IdentityRole
    {
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public bool IsDelete { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; } = DateTime.Now;
    }
}
