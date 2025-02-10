using Application.Contracts.InterfaceServices;
using Application.DTOs.HumanResources.Department;
using Application.DTOs.HumanResources.Employee;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services.ImplementationServices;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HumanResourcesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public HumanResourcesController(IEmployeeService employeeService
            , IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        #region Employee

        [HttpGet("exists/{irCode}")]
        public async Task<IActionResult> EmployeeExists(string irCode)
        {
            var exists = await _employeeService.EmployeeExistsByIrCodeAsync(irCode);
            return Ok(exists);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterEmployee([FromBody] AddEmployeeDTO employeeDTO)
        {
            if (employeeDTO == null) return BadRequest("Employee data is required");

            var result = await _employeeService.RegisterEmployeeAsync(employeeDTO, "Admin");

            return result switch
            {
                AddEmployeeResult.Success => Ok("Employee registered successfully"),
                AddEmployeeResult.ThereIs => Conflict("Employee already exists"),
                _ => BadRequest("Error registering employee")
            };
        }

        #endregion

        #region Department

        [HttpPost("Create-Department")]
        public async Task<IActionResult> CreateDepartment([FromBody] AddDepartmentDTO dto)
        {
            var result = await _departmentService.AddDepartment(dto,"Admin");

            if (result == AddDepartmentResult.Success)
                return Ok(new { message = "دپارتمان با موفقیت اضافه شد" });

            return BadRequest(new { message = "ثبت دپارتمان ناموفق بود" });
        }

        #endregion
    }
}
