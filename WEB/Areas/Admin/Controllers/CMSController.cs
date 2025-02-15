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

        #endregion


        #region Role Management

        [HttpGet("role-list")]
        public IActionResult SiteRoleList()
        {
            return View();
        }

        #endregion
    }
}
