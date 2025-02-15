using Application.DTOs.IdentityAccount.AssignRole;
using Application.DTOs.IdentityAccount.Role;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(CreateRoleDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _roleService.CreateRole(model);
            if (result)
            {
                TempData["SuccessMessage"] = "نقش جدید با موفقیت اضافه شد.";
                return RedirectToAction("SiteRoleList"); // هدایت به لیست نقش‌ها
            }
            TempData["ErrorMessage"] = "این نقش قبلاً ثبت شده است.";
            return View(model);
        }
        #endregion


        #region AssignRole

        [HttpGet("assign-role")]
        public async Task<IActionResult> AssignRoleToUser()
        {
            var users = await _roleService.GetUsersAsync();
            var roles = await _roleService.GetRolesAsync();

            var viewModel = new AssignRoleViewModel
            {
                Users = users,
                Roles = roles
            };

            return View(viewModel);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var result = await _roleService.AssignRoleToUser(model);
            if (result)
            {
                TempData["SuccessMessage"] = "نقش با موفقیت اختصاص داده شد.";
                return RedirectToAction("AssignRoleToUser");
            }

            TempData["ErrorMessage"] = "خطا در اختصاص نقش به کاربر.";
            return RedirectToAction("AssignRoleToUser");
        }



        #endregion
    }
}
