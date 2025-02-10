using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices;
using Application.DTOs.HumanResources;
using Application.DTOs.HumanResources.Employee;
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

        #region Check Exist User

        public async Task<bool> EmployeeExistsByIrCodeAsync(string irCode)
        {
            var employee = await _employeeRepository.GetEmployeeByIrCodeAsync(irCode);
            return employee != null;
        }

        public async Task<bool> EmployeeExistsByMobileAsync(string mobile)
        {
            var employee = await _employeeRepository.EmployeeExistsByMobileAsync(mobile);
            return employee != null;
        }

        public async Task<bool> EmployeeExistsByBirthCertificateNumberAsync(string birthCertificateNumber)
        {
            var employee = await _employeeRepository.EmployeeExistsByBirthCertificateNumberAsync(birthCertificateNumber);
            return employee != null;
        }

        public async Task<bool> EmployeeExistsByEmailAsync(string email)
        {
            var employee = await _employeeRepository.EmployeeExistsByEmailAsync(email);
            return employee != null;
        }

        #endregion

        #region Add Employee

        public async Task<AddEmployeeResult> RegisterEmployeeAsync
            (AddEmployeeDTO employeeDTO, string currentUser)
        {

            using var transaction = await _employeeGenericRepository.BeginTransactionAsync();

            try
            {

                var isExistIRCode = await EmployeeExistsByIrCodeAsync(employeeDTO.IRCode);
                var isExistMobile = await EmployeeExistsByMobileAsync(employeeDTO.Mobile);
                var isExistEmail = await EmployeeExistsByEmailAsync(employeeDTO.Email!);
                var isExistbirthCertificate = await EmployeeExistsByBirthCertificateNumberAsync(employeeDTO.BirthCertificateNumber);


                if (isExistIRCode || isExistMobile || isExistEmail || isExistbirthCertificate)
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
                    DateOfEmployment = Convert.ToDateTime(employeeDTO.DateOfEmployment),
                    FamiliarPhone = employeeDTO.FamiliarPhone,

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

                await transaction.CommitAsync();

                return AddEmployeeResult.Success;
            }
            catch (Exception)
            {

                // در صورت بروز خطا، Transaction را Rollback کن
                await transaction.RollbackAsync();

                // اگر ثبت ApplicationUser موفق نبود، Employee را حذف کن
                var existingEmployee = await _employeeRepository.GetEmployeeByIrCodeAsync(employeeDTO.IRCode);
                if (existingEmployee != null)
                {
                    // حذف Employee
                    _employeeGenericRepository.DeletePermanent(existingEmployee);
                }

                // اگر ثبت Employee موفق نبود، ApplicationUser را حذف کن
                var userName = employeeDTO.EmployeeCode; // فرض بر این است که EmployeeID برابر با UserName است
                await _userService.DeleteApplicationUserAsync(userName);

                throw new Exception("ثبت با مشکلی مواجه شد");
            }

        }

        #endregion
    }
}
