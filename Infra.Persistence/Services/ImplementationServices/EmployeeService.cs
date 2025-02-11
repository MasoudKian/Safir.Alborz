using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices;
using Application.DTOs.HumanResources;
using Application.DTOs.HumanResources.Employee;
using Application.Utils;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.Extensions.Logging;
using Persistence.Services.Repositories;
using System.Linq;

namespace Persistence.Services.ImplementationServices
{
    public class EmployeeService : IEmployeeService
    {
        #region ctor DI

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenericRepository<Employee> _employeeGenericRepository;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository employeeRepository
            , IGenericRepository<Employee> employeeGenericRepository
            , IUserService userService
            , IDepartmentService departmentService
            ,ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _employeeGenericRepository = employeeGenericRepository;
            _userService = userService;
            _departmentService = departmentService;
            _logger = logger;
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

        public async Task<AddEmployeeResult> RegisterEmployeeAsync(AddEmployeeDTO employeeDTO, string currentUser)
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

                var department = await _departmentService.GetDepartmentByIdAsync(employeeDTO.DepartmentId);
                if (department == null)
                {
                    return AddEmployeeResult.DepartmentNotFound;
                }
                // انتخاب 3 حرف اول دپارتمان مورد نظر
                string departmentFirstLetter = GetDepartmentCode.GetDepartmentCodeByName(department.DepartmentName);
                string randomCode = GenerateCode.GenerateEmployeeCode();
                string employeeCode = $"{departmentFirstLetter}{randomCode}";

                string imagePath = string.Empty;

                if (employeeDTO.ProfileImage != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var extension = Path.GetExtension(employeeDTO.ProfileImage.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        return AddEmployeeResult.Error;
                    }

                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Employees");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = $"{Guid.NewGuid()}_{employeeDTO.ProfileImage.FileName}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await employeeDTO.ProfileImage.CopyToAsync(fileStream);
                    }

                    imagePath = $"/Images/Employees/{uniqueFileName}";
                }

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
                    Education = (Education)employeeDTO.Education,
                    FieldOfStudy = employeeDTO.FieldOfStudy,
                    DateOfEmployment = DateTime.Now,
                    FamiliarPhone = employeeDTO.FamiliarPhone,
                    DepartmentId = employeeDTO.DepartmentId,
                    RegisteredBy = currentUser,
                    RegisteredDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    BirthDate = employeeDTO.BirthDate,
                    ImageAddress = imagePath,
                };

                var createdEmployee = await _employeeGenericRepository.CreateAsync(newEmployee);
                _logger.LogInformation($"Employee Created: {createdEmployee.EmployeeID}");

                var user = new AddUserForEmployeeDTO()
                {
                    FirsName = newEmployee.FirstName,
                    LastName = newEmployee.LastName,
                    UserName = newEmployee.EmployeeID,
                    Email = newEmployee.Email!,
                    Password = employeeDTO.Password,
                };

                var userId = await _userService.CreateEmployeeWithApplicationUser(user);
                _logger.LogInformation($"User Created with ID: {userId}");

                await transaction.CommitAsync();
                return AddEmployeeResult.Success;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "خطا در ثبت کارمند");

                var userName = employeeDTO.EmployeeCode;
                if (!string.IsNullOrEmpty(userName))
                {
                    await _userService.DeleteApplicationUserAsync(userName);
                }

                throw new InvalidOperationException("خطایی در ثبت کارمند رخ داده است", ex);
            }
        }


        #endregion
    }
}
