using Application.Models.AuthenticationIdentity;

namespace Application.Contracts.Interfaces.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest authRequest);
        Task<RegisterResponse> RegisterAsync(RegisterRequest authRequest);
    }
}
