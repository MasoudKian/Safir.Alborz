using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Department;
using Application.DTOs.HumanResources.Employee;
using Application.DTOs.HumanResources.Position;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services.ImplementationServices;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    
    public class HumanResourcesController : ControllerBase
    {
        #region ctor DI

        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionService _positionService;

        public HumanResourcesController(IEmployeeService employeeService
            , IDepartmentService departmentService
            , IPositionService positionService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _positionService = positionService;
        }

        #endregion

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
            if (await _departmentService.DepartmentExistsAsync(dto.Name))
            {
                return BadRequest(new { message = "دپارتمان با این نام قبلاً ثبت شده است." });
            }


            var result = await _departmentService.AddDepartment(dto);

            if (result == AddDepartmentResult.Success)
                return Ok(new { message = "دپارتمان با موفقیت اضافه شد" });

            return BadRequest(new { message = "ثبت دپارتمان ناموفق بود" });
        }

        #endregion


        #region Position

        [HttpPost("Create-Position")]
        public async Task<IActionResult> CreatePosition([FromBody] CreateOrUpdatePositionDTO positionDTO)
        {
            if (await _positionService.PositionExistAsync(positionDTO.Title))
            {
                return BadRequest(new { message = "سمت با این نام قبلاً ثبت شده است." });
            }

            var result = await _positionService.AddPositionAsync(positionDTO);
            if (result == PositionResult.Success)
                return Ok(new
                {
                    message = "سمت با موفیت ثبت شد"
                });

            return BadRequest(new { message = "ثبت سمت ناموفق بود" });
        }

        #endregion


    }
}
