using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class CMSController : AdminBaseController
    {

        #region User Management

        [HttpGet("user-list")]
        public IActionResult SiteUserList()
        {
            return View();
        }

        [HttpGet("add-user")]
        public IActionResult AddUser() 
        {
            return View();
        }

        #endregion




        #region Role Management

        [HttpGet("role-list")]
        public IActionResult SiteRoleList()
        {
            return View();
        }

        [HttpGet("add-role")]
        public IActionResult AddRole()
        {
            return View();
        }
        #endregion


        #region AssignRole

        [HttpGet("assign-role")]
        public IActionResult AssignRoleToUser()
        {
            return View();
        }

        #endregion
    }
}
