using Book.Api.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Book.Api.Tests;

public class TestBookApiApp : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.AddTransient(sp =>
            {
                // Replace SQLite with the in memory provider for tests
                return new DbContextOptionsBuilder<HotelContext>()
                            .UseInMemoryDatabase("BookDb", root)
                            .UseApplicationServiceProvider(sp)
                            .Options;
            });
        });

        return base.CreateHost(builder);
    }
}
