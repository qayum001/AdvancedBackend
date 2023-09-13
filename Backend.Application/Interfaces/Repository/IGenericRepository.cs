using Backend.Domain.Common.Interfaces;

namespace Backend.Application.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(Guid Id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync (T entity);
        Task<T> DeleteAsync (T entity);
    }
}
