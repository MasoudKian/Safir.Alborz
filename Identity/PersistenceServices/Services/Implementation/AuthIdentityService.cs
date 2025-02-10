using Application.DTOs.Account;
using Application.DTOs.IdentityAccount;
using Identity.Model;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.PersistenceServices.Services.Implementation
{
    public class AuthIdentityService : IAuthIdentityService
    {
        #region ctor DI

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthIdentityService(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        public async Task<SignInResult> LoginAsync(AuthLoginRequest request)
        {
            ApplicationUser user;

            if (request.Email.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(request.Email)
                    ?? throw new Exception($"کاربری با ایمیل {request.Email} پیدا نشد.");
            }
            else
            {
                user = await _userManager.FindByNameAsync(request.Email)
                    ?? throw new Exception($"کاربری با نام کاربری {request.Email} پیدا نشد.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                throw new Exception($"اطلاعات کاربری برای {request.Email} معتبر نیست.");
            }

            return result; // ورود موفق
        }


        public async Task<IdentityResult> RegisterAsync(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            return await _userManager.CreateAsync(user, request.Password);
        }
    }
}
