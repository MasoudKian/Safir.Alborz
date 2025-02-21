using Application.DTOs.HumanResources.Employee;
using Application.DTOs.MSCRMdto;
using Domain.Entities.MSCRM;

namespace Application.Contracts.InterfaceServices.MSCRM
{
    public interface IMSCRMService 
    {
        Task<Marketer> AddMarketer(AddMarketerDTO addMarketerDTO);
        Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM();

    }
}
