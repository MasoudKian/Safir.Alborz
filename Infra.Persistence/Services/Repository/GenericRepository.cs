using Application.Contracts.Interfaces.IGeneric;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        #region ctor DI

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #endregion

        public async Task<T> CreateAsync(T entity)
        {
            entity.RegisteredDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
            await SaveChagnesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllEntitiesAsyncJustForRead()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEntityExist(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChagnesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
