using Domain.Entities.HumanResources.EmployeeManagement;

namespace Domain.Interfaces.Repositories.HumanResources
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIrCodeAsync(string irCode);

        Task<Employee> EmployeeExistsByBirthCertificateNumberAsync(string birthCertificateNumber);

        Task<Employee> EmployeeExistsByMobileAsync(string mobile);

        Task<Employee> EmployeeExistsByEmailAsync(string email);

        Task<List<Employee>> GetAllEmployees();

        Task<int> GetTotalEmployeesCount();
    }
}
