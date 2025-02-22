using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Entities.MSCRM;

namespace Domain.Interfaces.Repositories
{
    public interface IMSCRMRepository
    {
        Task<Marketer> CreateMarketer(Marketer marketer);
        Task<List<Employee>> GetListCRMEmployeesAsync();
    }
}
