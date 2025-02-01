using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WEB.ViewComponents
{
    #region Site Header

    public class SiteHeaderViewComponent : ViewComponent
    {
        //private readonly UserManager<ApplicationUserIdentity> _userManager;

        //public SiteHeaderViewComponent(UserManager<ApplicationUserIdentity> userManager)
        //{
        //    _userManager = userManager;
        //}

        public SiteHeaderViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //if (HttpContext.User.Identity?.IsAuthenticated == true)
            //{
            //    var email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            //    if (!string.IsNullOrEmpty(email))
            //    {
            //        var applicationUser = await _userManager.FindByEmailAsync(email);
            //        if (applicationUser != null)
            //        {
            //            ViewBag.FullName = applicationUser.UserName;

            //            if (await _userManager.IsInRoleAsync(applicationUser, "PowerAdmin"))
            //            {
            //                ViewBag.Role = "PowerAdmin";
            //            }
            //            else if (await _userManager.IsInRoleAsync(applicationUser, "User"))
            //            {
            //                ViewBag.Role = "User";
            //            }
            //        }
            //    }
            //}

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
