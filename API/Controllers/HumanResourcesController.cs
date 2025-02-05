using Application.Contracts.InterfaceServices;
using Application.DTOs.HumanResources;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HumanResourcesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public HumanResourcesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

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
    }
}
