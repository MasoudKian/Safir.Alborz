using Application.DTOs.HumanResources.Employee;
using Application.DTOs.IdentityAccount.User;

namespace Application.Contracts.Interfaces.UserServices
{
    public interface IUserService
    {
        Task<string> CreateEmployeeWithApplicationUser
            (AddUserForEmployeeDTO userForEmployeeDTO);
        Task DeleteApplicationUserAsync(string userName);

        Task<List<UserListDTO>> GetUsersWithRolesAsync();
        Task<UsersCountDTO> GetUsersCountAsync();

        Task<int> GetTotalUsersAsync();
        Task<int> GetActiveUsersAsync();
        Task<int> GetNewUsersAsync();
        Task<int> GetInactiveUsersAsync();

        Task<bool> DeactivateUserAsync(string userId);
        Task<bool> ActivateUserAsync(string userId);
        
    }
}
