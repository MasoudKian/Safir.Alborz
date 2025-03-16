using Application.Contracts.Interfaces.UserServices;
using Application.DTOs.HumanResources.Employee;
using Application.DTOs.IdentityAccount.User;
using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.PersistenceServices.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<string> CreateEmployeeWithApplicationUser
            (AddUserForEmployeeDTO userForEmployeeDTO)
        {
            var user = new ApplicationUser
            {
                FirstName = userForEmployeeDTO.FirsName,
                LastName = userForEmployeeDTO.LastName,
                UserName = userForEmployeeDTO.UserName,
                Email = userForEmployeeDTO.Email,

            };

            var result = await _userManager.CreateAsync(user, userForEmployeeDTO.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Error creating user: {errors}");
            }


            return user.Id;
        }

        public async Task DeleteApplicationUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }


        #region User Manager

        // دریافت لیست کاربران با نقش‌هایشان
        public async Task<List<UserListDTO>> GetUsersWithRolesAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<UserListDTO>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                bool isLockedOut = await _userManager.IsLockedOutAsync(user); // چک کردن قفل بودن کاربر

                userList.Add(new UserListDTO
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Roles = roles.ToList(),
                    IsActive = !user.IsDelete,
                    CreateDate = (DateTime)user.CreatedDate!,
                    AccessFailedCount = user.AccessFailedCount, // مقداردهی تعداد ورودهای ناموفق
                    IsLockedOut = isLockedOut // مقداردهی قفل بودن حساب
                });
            }
            return userList;
        }

        public async Task<UsersCountDTO> GetUsersCountAsync()
        {
            return new UsersCountDTO
            {
                TotalUsers = await GetTotalUsersAsync(),
                ActiveUsers = await GetActiveUsersAsync(),
                NewUsers = await GetNewUsersAsync(),
                InactiveUsers = await GetInactiveUsersAsync()
            };
        }

        // دریافت تعداد کل کاربران
        public async Task<int> GetTotalUsersAsync()
        {
            return await _userManager.Users.CountAsync();
        }

        // دریافت تعداد کاربران فعال (کاربرانی که حذف نشده‌اند)
        public async Task<int> GetActiveUsersAsync()
        {
            return await _userManager.Users.CountAsync(u => !u.IsDelete);
        }

        // دریافت تعداد کاربران تازه‌وارد (ثبت‌نام شده در 30 روز اخیر)
        public async Task<int> GetNewUsersAsync()
        {
            var dateThreshold = DateTime.Now.AddDays(-30);
            return await _userManager.Users.CountAsync(u => u.CreatedDate >= dateThreshold);
        }

        // دریافت تعداد کاربران غیرفعال (کاربرانی که حذف شده‌اند)
        public async Task<int> GetInactiveUsersAsync()
        {
            return await _userManager.Users.CountAsync(u => u.IsDelete);
        }

        #endregion


        public async Task<bool> DeactivateUserAsync(string userId)
        {
            
            var user = await _userManager.FindByIdAsync(userId) 
                ?? throw new Exception("کاربر مورد نظر یافت نشد.");

            user.IsDelete = true; // غیرفعال کردن کاربر
            user.LastUpdateDate = DateTime.Now; // به‌روزرسانی تاریخ آخرین تغییر

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> ActivateUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("کاربر مورد نظر یافت نشد.");

            user.IsDelete = false; // غیرفعال کردن کاربر
            user.LastUpdateDate = DateTime.Now; // به‌روزرسانی تاریخ آخرین تغییر

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
