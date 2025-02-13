using Application.Contracts.InterfaceServices.HumanResources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WEB.Areas.Admin.ViewComponents
{
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
