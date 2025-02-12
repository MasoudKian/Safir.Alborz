using Application.Contracts.Interfaces.Repositories.HumanResources;
using Application.DTOs.HumanResources.Position;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services.Repository;

namespace Persistence.Services.Repositories.HumanResources
{
    public class PositionRepository : GenericRepository<Position> , IPositionRepository
    {
        private readonly SafirDbContext _dbContext;
        public PositionRepository(SafirDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task AddPosiitionAsync(Position position)
        {
            await _dbContext.AddAsync(position);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Position>> GetAllAsync()
        {
            return await _dbContext.Positions.Where(p=>!p.IsDelete).ToListAsync();
        }

        public async Task<Position> GetByIdAsync(int id)
        {
            return await _dbContext.Positions.FindAsync(id);
        }

        public async Task<bool> PositionExistAsync(string positionName)
        {
            return await _dbContext.Positions.AnyAsync(p => !p.IsDelete && p.Title == positionName);
        }
    }
}
