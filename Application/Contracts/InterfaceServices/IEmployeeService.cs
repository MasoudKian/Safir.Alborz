using Application.DTOs.HumanResources;

namespace Application.Contracts.InterfaceServices
{
    public interface IEmployeeService
    {
        Task<bool> EmployeeExistsByIrCodeAsync(string irCode);
        Task<bool> EmployeeExistsByBirthCertificateNumberAsync(string birthCertificateNumber);
        Task<bool> EmployeeExistsByMobileAsync(string mobile);
        Task<bool> EmployeeExistsByEmailAsync(string email);


        Task<AddEmployeeResult> RegisterEmployeeAsync(AddEmployeeDTO employeeDTO
            ,string currentUser);
    }
}
