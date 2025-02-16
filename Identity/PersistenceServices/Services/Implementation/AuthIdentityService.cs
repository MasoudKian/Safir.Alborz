using Application.DTOs.IdentityAccount;
using Application.Utils;
using Identity.Model;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.PersistenceServices.Services.Implementation
{
    public class AuthIdentityService : IAuthIdentityService
    {
        #region ctor DI

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthIdentityService(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor; // تزریق IHttpContextAccessor
        }

        #endregion

        #region Authentication 

        public async Task<(SignInResult Result, ApplicationUser User, IList<string> Roles)> 
            LoginAsync(AuthLoginRequest request)
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

            if (await _userManager.IsLockedOutAsync(user))
            {
                return (SignInResult.LockedOut, user, new List<string>());
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return (result, user, new List<string>());
            }

            var roles = await _userManager.GetRolesAsync(user);
            return (result, user, roles);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterRequest register)
        {
            var existUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == register.Email
            || u.UserName == register.UserName);
            if (existUser != null) throw new Exception($"User with this email or username already exists.");

            var userCode = GenerateCode.GenerateCodeUser();

            var user = new ApplicationUser()
            {
                FirstName = register.FirstName!,
                LastName = register.LastName!,
                Email = register.Email,
                UserName = register.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        #endregion


        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user!; // برگرداندن یوزر یا null

        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            // دسترسی به HttpContext برای دریافت کاربر جاری
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user;
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> IsInRoleAsync(string roleName)
        {
            var user = await GetCurrentUserAsync(); // دریافت کاربر جاری
            if (user == null)
            {
                throw new Exception("کاربر جاری پیدا نشد.");
            }

            return await _userManager.IsInRoleAsync(user, roleName);
        }


        // 

        // دریافت لیست کاربران با نقش‌هایشان
        public async Task<List<object>> GetUsersWithRolesAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new { user.Id, user.UserName, user.Email, Roles = roles });
            }
            return userList;
        }
    }
}
