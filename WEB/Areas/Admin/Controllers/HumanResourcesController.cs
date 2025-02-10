using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class HumanResourcesController : AdminBaseController
    {
        #region Home

        public IActionResult EmployeeManagement()
        {
            return View();
        }

        #endregion

        #region Department

        [HttpPost]
        public async Task<IActionResult> AddDepartment()
        {
            return View();
        }

        #endregion

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
