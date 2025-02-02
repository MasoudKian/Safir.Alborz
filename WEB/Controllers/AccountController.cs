using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
