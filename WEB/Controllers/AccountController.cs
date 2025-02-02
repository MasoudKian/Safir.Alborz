using Application.DTOs.Account;
using Application.Models.AuthenticationIdentity;
using Microsoft.AspNetCore.Mvc;
using WEB.Services;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthServices _authService;

        public AccountController(AuthServices authService)
        {
            _authService = authService;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var request = new RegisterRequest
                {
                    Email = model.Email!,
                    Password = model.Password!,
                    FirstName = model.FirstName!,
                    LastName = model.LastName!,
                    UserName = model.UserName!
                };

                await _authService.RegisterAsync(request);

                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
    }
}
