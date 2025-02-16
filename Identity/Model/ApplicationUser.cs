using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(200)]
        public string? FirstName { get; set; }

        [MaxLength(200)]
        public string? LastName { get; set; }


        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; } = DateTime.Now;
    }
}
