using Search.Api.DbModels;
using System.Linq.Expressions;

namespace Search.Api.Repository;

public class HotelRepositoryMock : IRepository<Hotel>
{
    private readonly List<Hotel> hotels = new();

    public HotelRepositoryMock()
    {
        hotels.Add(new()
        {
            Id = new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"),
            Name = "Trosa stadshotell",
            DeluxeRoomCount = 12,
            EconomyRoomCount = 20,
            StandardRoomCount = 40,
            Description = "Detta 1800-talshotell är centralt beläget i badorten Trosa och erbjuder ett spa, en restaurang och gratis WiFi. Här bor du 10 minuters promenad från hamnen. Trosa Golfklubb ligger mindre än 6 km bort. Till golfklubben Åda Golf & Country Club är det 5 km från hotellet.",
            Addrees = new()
            {
                City = "Trosa",
                Street = "Västra Långgatan 19",
                Country = "Sweden",
                ZipCode = "619 35"
            }
        });

        hotels.Add(new()
        {
            Id = new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"),
            Name = "First Hotel River C",
            DeluxeRoomCount = 10,
            EconomyRoomCount = 0,
            StandardRoomCount = 68,
            Description = "Detta hotell ligger bredvid Karlstad Congress Culture Centre och 5 minuters promenad från centrala Karlstad. Hotellet erbjuder gratis WiFi och moderna rum med Smart-TV.",
            Addrees = new()
            {
                City = "Karlstad",
                Street = "Tage Erlandergatan 10",
                Country = "Sweden",
                ZipCode = "65220"
            }
        });

        hotels.Add(new()
        {
            Id = new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"),
            Name = "Port hotel",
            DeluxeRoomCount = 12,
            EconomyRoomCount = 20,
            StandardRoomCount = 40,
            Description = "Detta hotell ligger på Karlshamns huvudgata, bara 650 meter från Stortorget. Port Hotel har gratis WiFi och en stor privat parkeringsplats. Som gäst erbjuds du te, kaffe, frukt och kakor 24 timmar om dygnet ",
            Addrees = new()
            {
                City = "Karlshamn",
                Street = "Drottninggatan 102",
                Country = "Sweden",
                ZipCode = "374 38"
            }
        });

    }
    public Task<int> CountAsync(Expression<Func<Hotel, bool>> filter, CancellationToken cancellationToken = default)
    {
        int count = hotels.Where(filter.Compile()).Count();

        return Task.FromResult(count);
    }

    public void Delete(Guid id)
    {
        var hotel = hotels.Find(x => x.Id == id);
        if (hotel is not null)
        {
            hotels.Remove(hotel);
        }
    }

    public Task<IEnumerable<Hotel>> FilterAsync(Expression<Func<Hotel, bool>> filter, int skip, int take, CancellationToken cancellationToken = default)
    {
        var list = hotels.Where(filter.Compile()).Skip(skip).Take(take).OrderBy(h => h.Name).ToList();
        return Task.FromResult<IEnumerable<Hotel>>(list);
    }

    public Task<Hotel?> FirstOrDefaultAsync(Expression<Func<Hotel, bool>> filter, CancellationToken cancellationToken = default)
    {
        var hotel = hotels.FirstOrDefault(filter.Compile());

        return Task.FromResult(hotel);
    }

    public Task<IEnumerable<Hotel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IEnumerable<Hotel>)hotels);
    }

    public Task<Hotel?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var hotel = hotels.FirstOrDefault(h => h.Id == id);

        return Task.FromResult(hotel);
    }

    public Task InsertAsync(Hotel model, CancellationToken cancellationToken = default)
    {
        hotels.Add(model);
        return Task.CompletedTask;
    }

    public void Update(Hotel model)
    {
        var hotel = hotels.First(h => h.Id == model.Id);

        hotel.Name = model.Name;
        hotel.Description = model.Description;
        hotel.EconomyRoomCount = model.EconomyRoomCount;
        hotel.DeluxeRoomCount = model.DeluxeRoomCount;
        hotel.StandardRoomCount = model.StandardRoomCount;
        hotel.Addrees = model.Addrees;
    }
}
