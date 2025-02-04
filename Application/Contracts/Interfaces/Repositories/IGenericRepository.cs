using Domain.Entities;

namespace Application.Contracts.Interfaces.IGeneric
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityById(int id);
        Task<bool> IsEntityExist(int id);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAllEntitiesAsync();
        Task<IReadOnlyList<T>> GetAllEntitiesAsyncJustForRead();
        Task SaveChangesAsync();
    }
}
