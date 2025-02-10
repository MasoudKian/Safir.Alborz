using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class HumanResourcesController : AdminBaseController
    {
        #region Home

        [HttpGet("Employee-Management")]
        public IActionResult EmployeeManagement()
        {
            return View();
        }

        #endregion

        #region Add Employee

        [HttpGet("Add-Employee")]
        public IActionResult AddEmployee()
        {
            return View();  
        }

        //[HttpPost("Add-Employee")]
        //public IActionResult AddEmployee()
        //{
        //    return View();
        //}

        #endregion
        /// <summary>
        /// مدیریت استخدام
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("Recruitment-Management")]
        public IActionResult RecruitmentManagement()
        {
            return View();
        }
    }
}
