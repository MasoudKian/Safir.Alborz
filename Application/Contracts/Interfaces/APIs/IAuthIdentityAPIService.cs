using Application.DTOs.IdentityAccount;

namespace Application.Contracts.Interfaces.APIs
{
    public interface IAuthIdentityAPIService
    {
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<bool> LoginAsync(AuthLoginRequest request);
        Task LogoutAsync();

        Task<bool> IsInRoleAsync(string roleName);
    }
}
