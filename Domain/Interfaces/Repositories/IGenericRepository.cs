using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityById(int id);
        Task<T?> FindNameAsync(Expression<Func<T, bool>> predicate);
        Task<bool> IsEntityExist(int id);
        Task<bool> IsExistEntityName(string entityName);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        void DeletePermanent(T entity);
        IQueryable<T> GetAllEntitiesAsync();
        Task<IReadOnlyList<T>> GetAllEntitiesAsyncJustForRead();
        Task SaveChangesAsync();


        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
