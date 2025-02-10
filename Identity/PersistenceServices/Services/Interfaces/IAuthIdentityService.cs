
using Microsoft.AspNetCore.Identity;
using Application.DTOs.IdentityAccount;

namespace Identity.PersistenceServices.Services.Interfaces
{
    public interface IAuthIdentityService
    {
        Task<IdentityResult> RegisterAsync(RegisterRequest request);
        Task<SignInResult> LoginAsync(AuthLoginRequest request);
    }
}
