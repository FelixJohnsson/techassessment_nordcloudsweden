using Microsoft.EntityFrameworkCore;
using Search.Api.DbModels;
using System.Linq.Expressions;

namespace Search.Api.Repository;

public class HotelRepository : IRepository<Hotel>
{
    private readonly HotelContext _context;

    public HotelRepository(HotelContext context)
    {
        _context = context;
    }
    public async Task<int> CountAsync(Expression<Func<Hotel, bool>> filter, CancellationToken cancellationToken = default) =>
        await _context.Hotels.Where(filter).CountAsync(cancellationToken);

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Hotel>> FilterAsync(Expression<Func<Hotel, bool>> filter, int skip, int take, CancellationToken cancellationToken = default) =>
        await _context.Hotels.Where(filter).Skip(skip).Take(take).OrderBy(h => h.Name).ToListAsync(cancellationToken);
    public Task<Hotel?> FirstOrDefaultAsync(Expression<Func<Hotel, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Hotels.ToListAsync(cancellationToken);

    public Task<Hotel?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(Hotel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Hotel model)
    {
        throw new NotImplementedException();
    }
}
