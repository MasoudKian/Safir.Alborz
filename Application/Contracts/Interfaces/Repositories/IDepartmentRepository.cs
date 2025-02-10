using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Contracts.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task<Department?> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync();
    }
}
