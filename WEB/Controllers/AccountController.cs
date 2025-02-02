using Application.DTOs.Account;
using Application.Models.AuthenticationIdentity;
using Microsoft.AspNetCore.Mvc;
using WEB.Services;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        #region ctor DI

        private readonly AuthWebServices _authService;

        public AccountController(AuthWebServices authService)
        {
            _authService = authService;
        }

        #endregion

        #region Register

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
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

        #endregion


        #region Login

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null!)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);


            return View();
        }
        #endregion
    }
}
