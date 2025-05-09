﻿using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Employee;
using Application.Utils;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.HumanResources;
using Microsoft.Extensions.Logging;

namespace Application.Contracts.Services.ImplementationServices.HumanResources
{
    public class EmployeeService : IEmployeeService
    {
        #region ctor DI

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenericRepository<Employee> _employeeGenericRepository;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        

        public EmployeeService(IEmployeeRepository employeeRepository
            , IGenericRepository<Employee> employeeGenericRepository
            , IUserService userService
            , IDepartmentService departmentService
            , ILogger<EmployeeService> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeGenericRepository = employeeGenericRepository;
            _userService = userService;
            _departmentService = departmentService;
            _logger = logger;
            _mapper = mapper;
        }


        #endregion

        #region Get Employee By Id

        public async Task<GetEmployeeByCode> GetEmployeeByCode(string code)
        {
            var employee =await _employeeRepository.GetEmployeeByCode(code);
            if (employee == null)
            {
                return new GetEmployeeByCode()
                {
                    EmployeeID = "N/A",  // مقدار پیش‌فرض
                    FullName = "مدیر ارشد سیستم",
                    Image = "default-avatar.png", // تصویر پیش‌فرض
                    DepartmentName = "مدیریت",
                    PositionName = "PowerAdmin",
                    Phone = "نامشخص"
                };
            }

            return new GetEmployeeByCode()
            {
                EmployeeID = employee.EmployeeID,
                FullName = $"{employee.FirstName} {employee.LastName}",
                Image = employee.ImageAddress,
                DepartmentName = employee.Department.Name,
                PositionName = employee.Position.Title,
                Phone = employee.Mobile,
            };
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

                if (employeeDTO?.ProfileImage is { Length: > 0 }) // بررسی اینکه عکس معتبر است
                {
                    var allowedExtensions = new HashSet<string> { ".jpg", ".jpeg", ".png" };
                    var extension = Path.GetExtension(employeeDTO.ProfileImage.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(extension))
                    {
                        return AddEmployeeResult.Error;
                    }

                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Employees");

                    // اطمینان از وجود پوشه
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // ساخت نام فایل منحصر‌به‌فرد
                    string uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // ذخیره‌ی فایل به صورت امن
                    await using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await employeeDTO.ProfileImage.CopyToAsync(fileStream);
                    }

                    // تنظیم مسیر تصویر برای ذخیره در دیتابیس
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
                    PositionId = employeeDTO.PositionId,
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

        public async Task<bool> DeactiveEmployeeAsync(int employeeId, string currentUser)
        {
            using var transaction = await _employeeGenericRepository.BeginTransactionAsync();
            try
            {
                // غیر فعال کردن کارمند در جدول Employee
                var deactiveEmployee = await _employeeRepository.DeactiveEmployee(employeeId, currentUser);
                if (!deactiveEmployee) return false;

                // دریافت کارمند بر اساس ID
                var employee = await _employeeRepository.GetEmployeeById(employeeId);
                if (employee == null) return false;

                // غیر فعال کردن یوزر در AspNetUser
                var deactiveUser = await _userService.FindByUserNameAndDeactiveAsync(employee.EmployeeID);
                if (!deactiveUser)
                {
                    // اگر غیرفعال کردن کاربر موفق نبود، تراکنش را لغو کنیم
                    await transaction.RollbackAsync();
                    return false;
                }

                // اگر همه عملیات موفق بود، تراکنش را ذخیره کنیم
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                // اگر خطایی رخ دهد، تراکنش را لغو کنیم
                await transaction.RollbackAsync();
                return false;
            }
        }

        #region List Employee & Count 
        public async Task<List<EmployeeListDTO>> GetEmployeeListsAsync()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            var employeeMapper = _mapper.Map<List<EmployeeListDTO>>(employees);
            return employeeMapper;
        }        
        public async Task<List<EmployeeListDTO>> GetDeactiveEmployeeListsAsync()
        {
            var employees = await _employeeRepository.GetAllDeactiveEmployees();
            var employeeMapper = _mapper.Map<List<EmployeeListDTO>>(employees);
            return employeeMapper;
        }

        public async Task<int> GetTotalEmployeesCount()
        {
            return await _employeeRepository.GetTotalEmployeesCount();
        }
        #endregion


    }
}
