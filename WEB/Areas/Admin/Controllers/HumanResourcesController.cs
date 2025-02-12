using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistence.Services.ImplementationServices;
using System.Security.Claims;

namespace WEB.Areas.Admin.Controllers
{
    public class HumanResourcesController : AdminBaseController
    {
        #region ctor DI

        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public HumanResourcesController(IDepartmentService departmentService
            , IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        #endregion

        #region Home

        [HttpGet("Employee-Management")]
        public IActionResult EmployeeManagement()
        {

            return View();
        }

        #endregion

        #region Add Employee

        [HttpGet("Add-Employee")]
        public async Task<IActionResult> AddEmployee()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
            return View();  
        }

        [HttpPost("Add-Employee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeDTO addEmployee)
        {
            Console.WriteLine($"DepartmentId received: {addEmployee.DepartmentId}");
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

                return View(addEmployee);
            }

            var result = await _employeeService.RegisterEmployeeAsync(addEmployee, currentUserId!);

            switch (result)
            {
                case AddEmployeeResult.Success:
                    TempData[SuccessMessage] = "بازاریاب با موفقیت ثبت شد";
                    break;
                case AddEmployeeResult.ThereIs:
                    TempData[InfoMessage] = "بازاریاب قبلا در سیستم ثبت شده است.";
                    break;
                case AddEmployeeResult.Warning:
                    TempData[ErrorMessage] = "ثبت بازاریاب با مشکلی مواجه شد";
                    break;
                case AddEmployeeResult.DepartmentNotFound:
                    TempData[ErrorMessage] = "دپارتمان یافت نشد!";
                    break;
                case AddEmployeeResult.Error:
                    TempData[ErrorMessage] = "ثبت بازاریاب با مشکلی مواجه شد ، لطفا با پشتیبانی تماس بگیرید.";
                    break;
            }
            return RedirectToAction("EmployeeManagement");
        }

        #endregion

        #region مدیریت استخدام

        [HttpGet("Recruitment-Management")]
        public IActionResult RecruitmentManagement()
        {
            return View();
        }

        #endregion

        /// مدیریت استخدام

    }
}
