using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Contracts.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIrCodeAsync(string irCode);
    }
}
