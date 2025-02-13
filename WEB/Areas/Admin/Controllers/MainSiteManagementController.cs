using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class MainSiteManagementController : AdminBaseController
    {
        public IActionResult SiteUserList()
        {
            return View();
        }
    }
}
