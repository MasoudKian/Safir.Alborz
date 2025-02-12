using Application.DTOs.HumanResources.Department;
using Application.DTOs.HumanResources.Position;
using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Contracts.Interfaces.Repositories.HumanResources
{
    public interface IPositionRepository
    {
        Task AddPosiitionAsync(Position position);
        Task<Position> GetByIdAsync(int id);
        Task<bool> PositionExistAsync(string positionName);
        Task<List<Position>> GetAllAsync();
    }
}
