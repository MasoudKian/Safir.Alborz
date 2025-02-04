using Application.Contracts.Interfaces.UserServices;
using Application.DTOs.HumanResources;
using Identity.Model;
using Microsoft.AspNetCore.Identity;

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
                Code = userForEmployeeDTO.Code,

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

    }
}
