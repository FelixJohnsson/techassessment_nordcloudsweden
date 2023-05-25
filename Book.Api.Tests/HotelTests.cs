using System.Net.Http.Json;
using System.Net;
using Xunit;
using Book.Api.Features.Hotel;

namespace Book.Api.Tests;

public class HotelTests
{
    [Fact]
    public async void AddHotel_NoId_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        //Act
        var response = await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { });

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void AddHotel_Id_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        Guid id = Guid.NewGuid();

        //Act
        var response = await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        var addHotelResponse = await response.Content.ReadFromJsonAsync<AddHotelResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(id, addHotelResponse?.Id);
    }

    [Fact]
    public async void GetHotel_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        Guid id = Guid.NewGuid();

        //Act
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        var response = await client.GetAsync($"/hotel/get/{id}");
        var hotelResponse = await response.Content.ReadFromJsonAsync<GetHotelResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(id, hotelResponse?.Id);
    }

    [Fact]
    public async void GetHotel_WrongId_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        //Act
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = Guid.NewGuid() });
        var response = await client.GetAsync($"/hotel/get/{Guid.NewGuid()}");

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async void DeleteHotel_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        Guid id = Guid.NewGuid();

        //Act
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        
        var response = await client.GetAsync($"/hotel/get/{id}");
        var hotelResponse = await response.Content.ReadFromJsonAsync<GetHotelResponse>();

        var deleteResponse = await client.DeleteAsync($"/hotel/delete/{id}");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(id, hotelResponse?.Id);
        Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
    }

    [Fact]
    public async void DeleteHotel_WrongId_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        Guid id = Guid.NewGuid();

        //Act
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });

        var deleteResponse = await client.DeleteAsync($"/hotel/delete/{Guid.NewGuid()}");

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, deleteResponse.StatusCode);
    }
}