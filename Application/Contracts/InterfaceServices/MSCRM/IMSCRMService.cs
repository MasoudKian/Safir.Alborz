using Application.DTOs.HumanResources.Employee;
using Application.DTOs.MSCRMdto;

namespace Application.Contracts.InterfaceServices.MSCRM
{
    public interface IMSCRMService 
    {
        Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM();
    }
}
