
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;
using System.Linq.Expressions;

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
            entity.RegisteredDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        /// <summary>
        /// IQueryable Get All
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAllEntitiesAsync()
        {
            return _dbSet.Where(e => !e.IsDelete);
        }

        public async Task<IReadOnlyList<T>> GetAllEntitiesAsyncJustForRead()
        {
            return await _dbSet.Where(e => !e.IsDelete).AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetEntityById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T?> FindNameAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsEntityExist(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id && !e.IsDelete);
        }

        public async Task<bool> IsExistEntityName(string entityName)
        {
            return await _dbSet.OfType<T>()
                .AnyAsync(e => EF.Property<string>(e, "Name") == entityName);
        }
        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.UtcNow;
            _dbSet.Update(entity);
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
