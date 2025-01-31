using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Code { get; set; }
        public string? Image { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; } = DateTime.Now;
    }
}
