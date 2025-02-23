using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WEB.Areas.Admin.Controllers
{
    public class HumanResourcesController : AdminBaseController
    {
        #region ctor DI

        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        public HumanResourcesController(IDepartmentService departmentService
            , IEmployeeService employeeService
            , IPositionService positionService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
            _positionService = positionService;
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

            var positions = await _positionService.GetAllPositionAsync();
            ViewBag.Positions = new SelectList(positions, "PositionId", "Title");

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
                    TempData[SuccessMessage] = "کارمند جدید با موفقیت ثبت شد";
                    break;
                case AddEmployeeResult.ThereIs:
                    TempData[WarningMessage] = $"کارمند با کد ملی : {addEmployee.IRCode} قبلا در س";
                    break;
                case AddEmployeeResult.Warning:
                    TempData[ErrorMessage] = "ثبت کارمند با مشکلی مواجه شد";
                    break;
                case AddEmployeeResult.DepartmentNotFound:
                    TempData[ErrorMessage] = "دپارتمان یافت نشد!";
                    break;
                case AddEmployeeResult.Error:
                    TempData[ErrorMessage] = "ثبت کارمند با مشکلی مواجه شد ، لطفا با پشتیبانی تماس بگیرید.";
                    break;
            }
            return RedirectToAction("EmployeeManagement");
        }

        #endregion

        #region Get Department

        [HttpGet("/GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();

            if (departments == null)
            {
                return Json(new List<SelectListItem>());
            }

            var departmentList = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            return Json(departmentList); // ✅ مقدار صحیح ارسال شد
        }

        #endregion

        #region مدیریت استخدام

        [HttpGet("Recruitment-Management")]
        public IActionResult RecruitmentManagement()
        {
            return View();
        }

        #endregion


    }
}
