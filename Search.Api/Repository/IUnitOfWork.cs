using Search.Api.DbModels;

namespace Search.Api.Repository;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    IRepository<Hotel> GetHotelRepository();
}
