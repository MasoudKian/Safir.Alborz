using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        #region About Us

        [HttpGet("aboutus")]
        public IActionResult AboutUs()
        {
            return View();
        }

        #endregion

        #region ContactUs

        [HttpGet("contactus")]
        public IActionResult ContactUs()
        {
            return View();
        }

        #endregion

        #region Blog

        [HttpGet("blog")]
        public IActionResult Blog()
        {
            return View();
        }

        [HttpGet("blog-detail")]
        public IActionResult BlogDetail()
        {
            return View();
        }

        #endregion

        [HttpGet("privacy-policy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
