using Application.DTOs.HumanResources.Department;

namespace Application.Contracts.InterfaceServices
{
    public interface IDepartmentService
    {
        Task<AddDepartmentResult> AddDepartment(AddDepartmentDTO addDepartment);
        Task<bool> DepartmentExistsAsync(string name);
    }
}
