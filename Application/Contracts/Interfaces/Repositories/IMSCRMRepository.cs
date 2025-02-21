using Application.DTOs.MSCRMdto;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Entities.MSCRM;

namespace Application.Contracts.Interfaces.Repositories
{
    public interface IMSCRMRepository
    {
        Task<Marketer> CreateMarketer(Marketer marketer);
        Task<List<Employee>> GetListCRMEmployeesAsync();
    }
}
