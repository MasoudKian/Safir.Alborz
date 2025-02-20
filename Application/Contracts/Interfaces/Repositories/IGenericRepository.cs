using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Contracts.Interfaces.IGeneric
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityById(int id);
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
