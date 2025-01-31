using Application.Contracts.Interfaces.Identity;
using Application.Models.AuthenticationIdentity;
using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Identity.PersistenceServices.Services
{
    public class AuthService : IAuthService
    {
        #region ctor DI

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JWTSetting> _jwtSetting;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager
            , IOptions<JWTSetting> jwtSetting, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSetting = jwtSetting;
            _signInManager = signInManager;
        }

        #endregion

        public Task<AuthResponse> LoginAsync(AuthRequest authRequest)
        {
            throw new NotImplementedException();
        }

        #region Register

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest authRequest)
        {
            var existUser = await _userManager.FindByNameAsync(authRequest.UserName);
            if (existUser != null) throw new Exception($"user name '{authRequest.UserName}' already exist");

            var user = new ApplicationUser()
            {
                Code = new Random().Next(100000, 999999).ToString(),
                Email = authRequest.Email,
                FirstName = authRequest.FirstName,
                LastName = authRequest.LastName,
                UserName = authRequest.UserName,
                Image = "",
                CreatedDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            };

            var existUserEmail = await _userManager.FindByEmailAsync(authRequest.Email);
            if (existUserEmail != null) throw new Exception($"Email '{authRequest.Email}' already exist");

            // todo register user
            var res = await _userManager.CreateAsync(user, authRequest.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegisterResponse() { UserId = user.Id };
            }
            throw new Exception($"Error ! {res.Errors}");
        }

        #endregion
    }
}
