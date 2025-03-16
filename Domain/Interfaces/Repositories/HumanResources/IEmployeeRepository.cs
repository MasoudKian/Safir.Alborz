using Domain.Entities.HumanResources.EmployeeManagement;

namespace Domain.Interfaces.Repositories.HumanResources
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByCode(string code);

        Task<Employee> GetEmployeeByIrCodeAsync(string irCode);

        Task<Employee> EmployeeExistsByBirthCertificateNumberAsync(string birthCertificateNumber);

        Task<Employee> EmployeeExistsByMobileAsync(string mobile);

        Task<Employee> EmployeeExistsByEmailAsync(string email);

        Task<int> GetTotalEmployeesCount();

        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> GetAllDeactiveEmployees();

        Task<Employee> GetEmployeeById(int employeeId);
        Task<bool> DeactiveEmployee(int employeeId, string currentUser);

    }
}
