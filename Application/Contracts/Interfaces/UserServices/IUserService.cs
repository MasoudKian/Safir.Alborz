namespace Application.Contracts.Interfaces.UserServices
{
    public interface IUserService
    {
        Task<string> CreateEmployeeWithApplicationUser
            (string userName, string email, string password, string employeeCode);
    }
}
