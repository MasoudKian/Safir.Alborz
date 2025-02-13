using Application.Contracts.InterfaceServices.HumanResources;
using Identity.PersistenceServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WEB.Areas.Admin.ViewComponents
{
    #region Sidebar

    public class SidbarAdminViewComponent : ViewComponent
    {
        private readonly IAuthIdentityService _authIdentityService;

        public SidbarAdminViewComponent(IAuthIdentityService authIdentityService)
        {
            _authIdentityService = authIdentityService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _authIdentityService.GetCurrentUserAsync();
            var roles = await _authIdentityService.GetRolesAsync(user) ?? new List<string>(); // مقداردهی پیش‌فرض لیست

            if (roles !=null)
            {
                ViewBag.Role = roles;
            }

            return View("SidbarAdmin", roles);
        }
    }

    #endregion

    #region  Department List

    public class DepartmentListViewComponent : ViewComponent
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentListViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _departmentService.GetAllDepartmentsAsync();
            return View("DepartmentList", list);
        }
    }

    #endregion

    #region Position List

    public class PositionListViewComponent : ViewComponent
    {
        private readonly IPositionService _positionService;

        public PositionListViewComponent(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _positionService.GetAllPositionAsync();
            return View("PositionList", list);
        }
    }

    #endregion

    #region Employee List

    public class EmployeeListViewComponent : ViewComponent
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeListViewComponent(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _employeeService.GetEmployeeListsAsync();
            return View("EmployeeList", list);
        }
    }


    public class EmployeeCountViewComponent : ViewComponent
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeCountViewComponent(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.TotalEmployees = await _employeeService.GetTotalEmployeesCount();
            return View("EmployeeCount");
        }
    }

    #endregion
}
