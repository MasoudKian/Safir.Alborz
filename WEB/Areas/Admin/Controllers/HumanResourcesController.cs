using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class HumanResourcesController : AdminBaseController
    {
        public IActionResult EmployeeManagement()
        {
            return View();
        }

        /// <summary>
        /// مدیریت استخدام
        /// </summary>
        /// <returns></returns>
        public IActionResult RecruitmentManagement()
        {
            return View();
        }
    }
}
