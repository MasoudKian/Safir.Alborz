using Application.DTOs.HumanResources;

namespace Application.Contracts.Interfaces.UserServices
{
    public interface IUserService
    {
        Task<string> CreateEmployeeWithApplicationUser
            (AddUserForEmployeeDTO userForEmployeeDTO);


    }
}
