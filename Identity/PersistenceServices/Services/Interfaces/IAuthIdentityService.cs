
using Microsoft.AspNetCore.Identity;
using Application.DTOs.IdentityAccount;
using Identity.Model;

namespace Identity.PersistenceServices.Services.Interfaces
{
    public interface IAuthIdentityService
    {
        Task<IdentityResult> RegisterAsync(RegisterRequest request);
        Task<SignInResult> LoginAsync(AuthLoginRequest request);
        Task LogoutAsync();

        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> GetCurrentUserAsync();

        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<bool> IsInRoleAsync(string roleName);
    }
}
