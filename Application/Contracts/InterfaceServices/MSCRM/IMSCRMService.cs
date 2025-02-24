using Application.DTOs.MSCRMdto;
using Domain.Enums;

namespace Application.Contracts.InterfaceServices.MSCRM
{
    public interface IMSCRMService 
    {
        Task<ValidationsResult> AddMarketer(AddMarketerDTO addMarketerDTO
            , string currentUser);
        Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM();
        Task<bool> CheckMarketerExists(int marketerId);
    }
}
