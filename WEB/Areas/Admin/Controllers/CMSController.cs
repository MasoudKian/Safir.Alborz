using Application.Contracts.Interfaces.UserServices;
using Application.DTOs.IdentityAccount.AssignRole;
using Application.DTOs.IdentityAccount.Role;
using Identity.PersistenceServices.Services.Implementation;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers
{
    public class CMSController(IRoleService roleService, IUserService userService) : AdminBaseController
    {

        #region ctor DI

        private readonly IRoleService _roleService = roleService;
        private readonly IUserService _userService = userService;

        #endregion

        #region User Management

        [HttpGet("user-list")]
        public async Task<IActionResult> SiteUserList()
        {
            var list = await _userService.GetUsersWithRolesAsync();
            return View(list);
        }

        [HttpGet("add-user")]
        public IActionResult AddUser() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeactivateUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                TempData[WarningMessage] = ("مشکلی به وجود آمد لطفا مجدد تلاش کنید.");
            }

            var result = await _userService.DeactivateUserAsync(userId);

            if (result)
            {
                TempData[SuccessMessage] = "کاربر با موفقیت غیرفعال شد.";
            }
            else
            {
                TempData[ErrorMessage] = "مشکلی در غیرفعال‌سازی کاربر رخ داد.";
            }

            return RedirectToAction("SiteUserList"); // تغییر مسیر به لیست کاربران
        }


        public async Task<IActionResult> ActivateUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                TempData[WarningMessage] = ("مشکلی به وجود آمد لطفا مجدد تلاش کنید.");
            }

            var result = await _userService.ActivateUserAsync(userId);

            if (result)
            {
                TempData[SuccessMessage] = "کاربر با موفقیت فعال شد.";
            }
            else
            {
                TempData[ErrorMessage] = "مشکلی در فعال‌سازی کاربر رخ داد.";
            }

            return RedirectToAction("SiteUserList"); // تغییر مسیر به لیست کاربران
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
                TempData[SuccessMessage] = "نقش جدید با موفقیت اضافه شد.";
                return RedirectToAction("SiteRoleList"); // هدایت به لیست نقش‌ها
            }
            TempData[ErrorMessage] = "این نقش قبلاً ثبت شده است.";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData[WarningMessage] = "مشکلی پیش آمده!";
                return View();
            }
            var role = await _roleService.GetRolesAsync();
            var currentRole = role.FirstOrDefault(r => r.Id == id);

            if (currentRole == null)
            {
                TempData[WarningMessage] = "نقش مورد نظر پیدا نشد ! ";
                return View();
            }

            // پر کردن DTO برای نمایش توی ویو
            var result = new EditRoleDTO
            {
                RoleId = currentRole.Id,
                RoleName = currentRole.Name,
                Description = (await _roleService.GetAllRoles()).Roles
                    .FirstOrDefault(r => r.RoleName == currentRole.Name)?.Description ?? string.Empty
            };

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleDTO editRole)
        {
            if (!ModelState.IsValid)
            {
                TempData[InfoMessage] = "لطفا اطلاعات را به درستی وارد کنید !";
                return View();
            }

            var result = await _roleService.EditRole(editRole);
            if (result != true)
            {
                TempData[WarningMessage] = "این نقش قبلا در سیستم ثبت شده !";
                return View();
            }
             
            TempData[SuccessMessage] = "نقش با موفقیت ویرایش شد";
            return RedirectToAction("SiteRoleList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactiveRole(string roleId)
        {
            if (!ModelState.IsValid)
            {
                TempData[InfoMessage] = "لطفا اطلاعات را به درستی وارد کنید !";
                return RedirectToAction("SiteRoleList");
            }

            var result = await _roleService.DeactivateRole(roleId);
            if (!result)
            {
                TempData[ErrorMessage] = "در دریافت اطلاعات مشکلی به وجود آمده است !";
                return RedirectToAction("SiteRoleList");
            }

            TempData[SuccessMessage] = "نقش با موفقیت حذف شد !";
            return RedirectToAction("SiteRoleList");

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
                TempData[SuccessMessage] = "نقش با موفقیت اختصاص داده شد.";
                return RedirectToAction("AssignRoleToUser");
            }

            TempData[ErrorMessage] = "خطا در اختصاص نقش به کاربر.";
            return RedirectToAction("AssignRoleToUser");
        }



        #endregion



    }
}
