using Application.DTOs.HumanResources;

namespace Application.Contracts.InterfaceServices
{
    public interface IEmployeeService
    {
        Task<bool> EmployeeExistsByIrCodeAsync(string irCode);

        Task<AddEmployeeResult> RegisterEmployeeAsync(AddEmployeeDTO employeeDTO
            ,string currentUser);
    }
}
