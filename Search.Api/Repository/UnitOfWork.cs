using Search.Api.DbModels;

namespace Search.Api.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly IRepository<Hotel> _hotelRepository;

    public UnitOfWork(IRepository<Hotel> hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    public IRepository<Hotel> GetHotelRepository() => _hotelRepository;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
