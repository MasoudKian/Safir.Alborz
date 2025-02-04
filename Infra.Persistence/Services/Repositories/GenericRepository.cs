using Application.Contracts.Interfaces.IGeneric;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Persistence.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        #region ctor DI

        private readonly SafirDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(SafirDbContext context)
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
            await SaveChangesAsync();
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

        public async Task<T> GetEntityById(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task<bool> IsEntityExist(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void DeletePermanent(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
