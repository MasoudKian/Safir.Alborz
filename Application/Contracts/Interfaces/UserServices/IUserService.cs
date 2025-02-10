using Application.DTOs.HumanResources.Employee;

namespace Application.Contracts.Interfaces.UserServices
{
    public interface IUserService
    {
        Task<string> CreateEmployeeWithApplicationUser
            (AddUserForEmployeeDTO userForEmployeeDTO);


        Task DeleteApplicationUserAsync(string userName);
    }
}
