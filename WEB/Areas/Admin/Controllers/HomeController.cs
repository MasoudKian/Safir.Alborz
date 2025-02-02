using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult AdminHome()
        {
            return View();
        }
    }
}
