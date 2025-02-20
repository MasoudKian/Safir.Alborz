using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Contracts.Interfaces.Repositories
{
    public interface IMSCRMRepository
    {
        Task<List<Employee>> GetListCRMEmployeesAsync();
    }
}
