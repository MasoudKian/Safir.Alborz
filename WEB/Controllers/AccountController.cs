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
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            try
            {
                // ایجاد یک شیء AuthRequest از LoginVM
                var authRequest = new AuthRequest
                {
                    Email = login.UsernameOrEmail, // اینجا می‌توانید از نام کاربری یا ایمیل استفاده کنید
                    Password = login.Password
                };

                // فراخوانی متد LoginAsync از AuthService
                var response = await _authService.LoginAsync(authRequest);

                // می‌توانید کاربر را به صفحه مناسب هدایت کنید
                return LocalRedirect(response.RedirectUrl); // استفاده از URL مناسب
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(login);
            }
        }


        #endregion
    }
}
