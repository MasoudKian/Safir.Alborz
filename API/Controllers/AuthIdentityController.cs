using Application.DTOs.IdentityAccount;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthIdentityController : ControllerBase
    {
        private readonly IAuthIdentityService _authIdentityService;

        public AuthIdentityController(IAuthIdentityService authIdentityService)
        {
            _authIdentityService = authIdentityService;
        }


        // ثبت‌نام
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authIdentityService.RegisterAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("کاربر با موفقیت ثبت‌نام شد.");
        }

        // ورود
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _authIdentityService.LoginAsync(request);
        //    if (result == null)
        //    {
        //        return Unauthorized("نام کاربری یا رمز عبور نادرست است.");
        //    }

        //    return Ok(result);
        //}

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authIdentityService.LogoutAsync();
            return Ok("شما با موفقیت خارج شدید.");
        }


        [HttpGet("is-in-role/{roleName}")]
        public async Task<IActionResult> IsInRole(string roleName)
        {
            try
            {
                bool isInRole = await _authIdentityService.IsInRoleAsync(roleName);
                return Ok(isInRole);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
