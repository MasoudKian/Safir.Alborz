﻿using Application.DTOs.HumanResources.Employee;

namespace Application.Contracts.InterfaceServices.HumanResources
{
    public interface IEmployeeService
    {
        Task<bool> EmployeeExistsByIrCodeAsync(string irCode);
        Task<bool> EmployeeExistsByBirthCertificateNumberAsync(string birthCertificateNumber);
        Task<bool> EmployeeExistsByMobileAsync(string mobile);
        Task<bool> EmployeeExistsByEmailAsync(string email);

        Task<GetEmployeeByCode> GetEmployeeByCode(string code);

        Task<AddEmployeeResult> RegisterEmployeeAsync(AddEmployeeDTO employeeDTO
            , string currentUser);

        Task<List<EmployeeListDTO>> GetEmployeeListsAsync();
        Task<List<EmployeeListDTO>> GetDeactiveEmployeeListsAsync();

        Task<int> GetTotalEmployeesCount();

        Task<bool> DeactiveEmployeeAsync(int employeeId, string currentUser);
    }
}
