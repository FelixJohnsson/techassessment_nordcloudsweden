using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Search.Api.DbModels;
using Search.Api.Models;
using Search.Api.Repository;
using System.Data.Common;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Search.Api.Tests;

public class SearchHandlerTests : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<HotelContext> _contextOptions;
    public SearchHandlerTests()
    {
        var hotels = new List<Hotel>
        {
            new()
            {
                Name = "Foo",
            },
            new()
            {
                Name = "Foo2",
            },
            new()
            {
                Name = "Bar",
            }
        };

        // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
        // at the end of the test (see Dispose below).
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite, including the connection opened above.
        _contextOptions = new DbContextOptionsBuilder<HotelContext>()
            .UseSqlite(_connection)
            .Options;

        // Create the schema and seed some data
        using var context = new HotelContext(_contextOptions);

        context.Database.EnsureCreated();
        context.AddRange(hotels);
        context.SaveChanges();
    }

    private HttpClient GetClient() =>
        new TestSearchApiApp().WithWebHostBuilder(builder => builder.ConfigureTestServices(s => s.AddTransient(_ => new HotelContext(_contextOptions)))).CreateClient();

    public void Dispose() => _connection.Dispose();


    [Fact]
    public async void SearchHotels_Ok()
    {
        SearchHotelsResult? result = await GetClient().GetFromJsonAsync<SearchHotelsResult>("/hotel/search?term=Foo&skip=0&page=10");

        Assert.Equal(2, result?.TotalCount);
        Assert.Equal("Foo", result?.Hotels.FirstOrDefault()?.Name);
    }

    [Fact]
    public async void SearchHotels_NotFound()
    {
        HttpResponseMessage response = await GetClient().GetAsync("/hotel/search?term=Foo");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async void SearchHotels_BadRequest()
    {
        HttpResponseMessage response = await GetClient().GetAsync("/hotel/search/Foo/0/10");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}