using Application.Contracts.InterfaceServices;
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
            return View("DepartmentList",list);
        }
    }

    #endregion
}
