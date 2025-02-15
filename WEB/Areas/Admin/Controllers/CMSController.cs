using Identity.Model;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEB.Areas.Admin.Controllers
{
    public class CMSController : AdminBaseController
    {

        #region ctor DI

        private readonly IRoleService _roleService;

        public CMSController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion

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
        public async Task<IActionResult> SiteRoleList()
        {
            var roles = await _roleService.GetAllRoles();
            return View(roles);
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
