using Domain.Entities.HumanResources.EmployeeManagement;

namespace Domain.Interfaces.Repositories.HumanResources
{
    public interface IPositionRepository
    {
        Task AddPosiitionAsync(Position position);
        Task<Position> GetByIdAsync(int id);
        Task<bool> PositionExistAsync(string positionName);
        Task<List<Position>> GetAllAsync();
    }
}
