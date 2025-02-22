using Application.DTOs.HumanResources.Department;

namespace Application.Contracts.InterfaceServices.HumanResources
{
    public interface IDepartmentService
    {
        Task<AddDepartmentResult> AddDepartment(AddDepartmentDTO addDepartment);
        Task<bool> DepartmentExistsAsync(string name);

        Task<GetDepartmentDTO> GetDepartmentByIdAsync(int id);

        Task<List<DepartmentListDTO>> GetAllDepartmentsAsync();
    }
}
