﻿using Application.Contracts.Interfaces.APIs;
using Application.DTOs.IdentityAccount;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WEB.Services.IdentityAPIs;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        #region ctor DI

        private readonly IAuthIdentityService _authIdentityService;

        public AccountController(IAuthIdentityService authIdentityService)
        {
            _authIdentityService = authIdentityService;
        }

        #endregion

        //#region For JWT

        //#region Register

        //[HttpGet("register")]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost("register")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var request = new RegisterRequest
        //        {
        //            Email = model.Email!,
        //            Password = model.Password!,
        //            FirstName = model.FirstName!,
        //            LastName = model.LastName!,
        //            UserName = model.UserName!
        //        };



        //        await _authService.RegisterAsync(request);

        //        return RedirectToAction("Login", "Account");
        //    }
        //    return View(model);
        //}

        //#endregion


        //#region Login

        //[HttpGet("login")]
        //public IActionResult Login(string returnUrl = null!)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    return View();
        //}

        //[HttpPost("login")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginVM login)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(login);
        //    }

        //    try
        //    {
        //        // ایجاد یک شیء AuthRequest از LoginVM
        //        var authRequest = new AuthRequest
        //        {
        //            Email = login.UsernameOrEmail, // اینجا می‌توانید از نام کاربری یا ایمیل استفاده کنید
        //            Password = login.Password
        //        };

        //        // فراخوانی متد LoginAsync از AuthService
        //        var response = await _authService.LoginAsync(authRequest);

        //        // می‌توانید کاربر را به صفحه مناسب هدایت کنید
        //        return LocalRedirect(response.RedirectUrl); // استفاده از URL مناسب
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        return View(login);
        //    }
        //}


        //#endregion

        //#endregion

        #region For Identity 

        #region Register

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _authIdentityService.RegisterAsync(model);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
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
        public async Task<IActionResult> Login(AuthLoginRequest model, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var (result, user, roles) = await _authIdentityService.LoginAsync(model);

                if (result.Succeeded)
                {
                    var role = roles.FirstOrDefault();

                    if (role == "AdminPanel")
                    {
                        return RedirectToAction("AdminHome", "Home", new { area = "Admin" });
                    }

                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "حساب شما قفل شده است. لطفاً بعداً تلاش کنید.");
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "دسترسی شما غیرمجاز است.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }



        #endregion

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _authIdentityService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

    }
}
