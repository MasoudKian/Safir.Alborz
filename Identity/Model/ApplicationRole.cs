using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class ApplicationRole : IdentityRole
    {
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
