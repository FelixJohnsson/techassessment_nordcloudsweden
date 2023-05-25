using System.Linq.Expressions;

namespace Search.Api.Repository;

public interface IRepository<T> where T : class
{
    void Update(T model);
    void Delete(Guid id);
    Task InsertAsync(T model, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter, int skip, int take, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
