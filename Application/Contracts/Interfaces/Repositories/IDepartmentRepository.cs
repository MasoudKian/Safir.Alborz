using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Contracts.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task<Department?> GetByIdAsync(int id);
        Task<bool> DepartmentExistsAsync(string departmentName);
        Task<List<Department>> GetAllAsync();
    }
}
