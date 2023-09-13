using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Repository;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
    Task<int> Save(CancellationToken cancellationToken);
    Task<int> SaveAndRemovecache(CancellationToken cancellationToken, params string[] cacheKeys);
    Task RollBack();
}
