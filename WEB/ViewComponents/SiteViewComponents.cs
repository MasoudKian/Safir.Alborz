using Application.Contracts.Interfaces.APIs;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WEB.ViewComponents
{
    #region Site Header

    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly IAuthIdentityService _authIdentityService;

        public SiteHeaderViewComponent(IAuthIdentityService authIdentityService)
        {
            _authIdentityService = authIdentityService;
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                var email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                if (!string.IsNullOrEmpty(email))
                {
                    var currentUser = await _authIdentityService.GetCurrentUserAsync();
                    if (currentUser != null)
                    {
                        ViewBag.FullName = currentUser.FirstName;

                        if (await _authIdentityService.IsInRoleAsync("PowerAdmin"))
                        {
                            ViewBag.Role = "PowerAdmin";
                        }
                        else if (await _authIdentityService.IsInRoleAsync("User"))
                        {
                            ViewBag.Role = "User";
                        }
                    }
                }
            }

            return View("SiteHeader");
        }


    }

    #endregion

    #region SiteFooter

    public class SiteFooterViewComponent : ViewComponent
    {
        public SiteFooterViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }

    #endregion

    #region HomeSlider

    public class HomeSliderViewComponent : ViewComponent
    {
        public HomeSliderViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("HomeSlider");
        }
    }

    #endregion
}
