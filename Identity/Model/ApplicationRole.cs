using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; } = string.Empty;
    }
}
