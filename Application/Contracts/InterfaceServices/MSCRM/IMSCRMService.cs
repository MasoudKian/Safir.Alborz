using Application.DTOs.MSCRMdto;
using Domain.Entities.MSCRM;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.InterfaceServices.MSCRM
{
    public interface IMSCRMService 
    {
        Task<ValidationsResult> AddMarketer(AddMarketerDTO addMarketerDTO);
        Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM();
        Task<bool> CheckMarketerExists(int marketerId);
    }
}
