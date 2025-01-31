using Application.Contracts.Interfaces.Identity;
using Application.Models.AuthenticationIdentity;
using Application.Utils;
using Azure.Core;
using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.PersistenceServices.Services
{
    public class AuthService : IAuthService
    {
        #region ctor DI

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JWTSetting> _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager
            , IOptions<JWTSetting> jwtSettings, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _signInManager = signInManager;
        }

        #endregion

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

        #region Login

        public async Task<AuthResponse> LoginAsync(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new Exception($"user with {authRequest.Email} not fount.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName!, authRequest.Password
                , false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"credentials for {authRequest.Email} arent valid.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email!,
                UserName = user.UserName!,
            };

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName !),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email!),
                new Claim(CustomeClaimTypes.Code,user.Code!),
                new Claim(CustomeClaimTypes.Uid,user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Value.Issuer,
                audience: _jwtSettings.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Value.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;

            #endregion
        }
    }
}
 