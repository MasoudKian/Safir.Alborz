using Application.DTOs.IdentityAccount.Role;
using Identity.Model;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Identity.PersistenceServices.Services.Implementation
{
    public class RoleService : IRoleService
    {
        #region ctor DI

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #endregion

        public async Task<bool> CreateRole(CreateRoleDTO model)
        {
            // بررسی تکراری بودن نقش
            var existingRole = await _roleManager.FindByNameAsync(model.RoleName);
            if (existingRole != null)
            {
                return false; // نقش از قبل وجود دارد
            }

            var newRole = new ApplicationRole
            {
                Name = model.RoleName,
                Description = model.Description,
                CreatedDate = DateTime.UtcNow // مقداردهی تاریخ ثبت
            };

            var result = await _roleManager.CreateAsync(newRole);
            return result.Succeeded;
        }

        public async Task<RolesResponseDTO> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var totalCount = roles.Count;

            var roleList = new List<RolesListDTO>();

            foreach (var role in roles)
            {
                // گرفتن کاربران مرتبط با این رول
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);

                // استخراج نام کاربران از لیست `ApplicationUser`
                var userNames = usersInRole.Select(u => u.UserName).ToList();

                roleList.Add(new RolesListDTO
                {
                    RoleName = role.Name,
                    Description = role.Description,
                    CreatedDate = (DateTime)role.CreatedDate!, // مقدار تاریخ ثبت
                    UserCount = usersInRole.Count, // تعداد کاربران مرتبط
                    UserNames = userNames // اضافه کردن نام کاربران
                });
            }

            return new RolesResponseDTO
            {
                TotalCount = totalCount,
                Roles = roleList
            };
        }

    }
}
