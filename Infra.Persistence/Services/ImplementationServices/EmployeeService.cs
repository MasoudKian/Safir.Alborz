using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices;
using Application.DTOs.HumanResources;
using Application.Utils;
using Domain.Entities.HumanResources.EmployeeManagement;

namespace Persistence.Services.ImplementationServices
{
    public class EmployeeService : IEmployeeService
    {
        #region ctor DI

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenericRepository<Employee> _employeeGenericRepository;
        private readonly IUserService _userService;

        public EmployeeService(IEmployeeRepository employeeRepository
            , IGenericRepository<Employee> employeeGenericRepository
            , IUserService userService)
        {
            _employeeRepository = employeeRepository;
            _employeeGenericRepository = employeeGenericRepository;
            _userService = userService;
        }



        #endregion

        public async Task<bool> EmployeeExistsByIrCodeAsync(string irCode)
        {
            var employee = await _employeeRepository.GetEmployeeByIrCodeAsync(irCode);
            return employee != null;
        }

        public async Task<AddEmployeeResult> RegisterEmployeeAsync
            (AddEmployeeDTO employeeDTO, string currentUser)
        {
            var isExistEmployee = await EmployeeExistsByIrCodeAsync(employeeDTO.IRCode);
            if (isExistEmployee)
            {
                return AddEmployeeResult.ThereIs;
            }

            var employeeCode = GenerateCode.GenerateEmployeeCode();

            var newEmployee = new Employee()
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                IRCode = employeeDTO.IRCode,
                BirthCertificateNumber = employeeDTO.BirthCertificateNumber,
                Mobile = employeeDTO.Mobile,
                Email = employeeDTO.Email,
                Address = employeeDTO.Address,
                EmployeeID = employeeCode,
                Education = employeeDTO.Education,
                FieldOfStudy = employeeDTO.FieldOfStudy,
                DateOfEmployment = employeeDTO.DateOfEmployment,
                FamiliarPhone = employeeDTO.FamiliarPhone,
                Password = employeeDTO.IRCode,
                
                RegisteredBy = currentUser,
                 
            };

            var createdEmployee = await _employeeGenericRepository.CreateAsync(newEmployee);
            Console.WriteLine($"Employee Created: {createdEmployee.EmployeeID}");

            var user = new AddUserForEmployeeDTO()
            {
                FirsName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                UserName = newEmployee.EmployeeID,
                Email = employeeDTO.Email!,
                Code = newEmployee.EmployeeID,
                Password = employeeDTO.Password,
                
            };

            var userId = await _userService.CreateEmployeeWithApplicationUser(user);
            Console.WriteLine($"User Created with ID: {userId}");

            return AddEmployeeResult.Success;   
            
        }
    }
}
