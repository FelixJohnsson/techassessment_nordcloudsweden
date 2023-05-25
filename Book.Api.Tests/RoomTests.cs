using System.Net.Http.Json;
using System.Net;
using Xunit;
using Book.Api.Features.Hotel;
using Book.Api.Features.Room;
using AutoFixture;
using Book.Api.Context.DbRecords;
using Book.Api.Features.Bookings;

namespace Book.Api.Tests;

public class RoomTests
{
    [Fact]
    public async void AddRoom_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });

        string roomName = fixture.Create<string>();

        //Act
        var response = await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = hotelId, Name = roomName, Type = Context.DbRecords.RoomType.Economy });
        var addRoomResponse = await response.Content.ReadFromJsonAsync<AddRoomResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(addRoomResponse?.Id);
    }

    [Fact]
    public async void AddRoom_NoHotel_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });

        string roomName = fixture.Create<string>();

        //Act
        var response = await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = Guid.NewGuid(), Name = roomName, Type = Context.DbRecords.RoomType.Economy });

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }    

    [Fact]
    public async void UpdateRoom_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();
        string roomName = fixture.Create<string>();

        Guid id = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        var addResponse = await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = id, Name = roomName, Type = RoomType.Economy });
        var roomResponse = await addResponse.Content.ReadFromJsonAsync<AddRoomResponse>();

        UpdateRoomRequest request = new()
        {
            Id = roomResponse.Id,
            Name = fixture.Create<string>(),
            Type = RoomType.Standard
        };

        //Act
        var response = await client.PutAsJsonAsync("/room/update", request);        
        var updateResponse = await response.Content.ReadFromJsonAsync<UpdateRoomResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(roomResponse.Id, updateResponse?.Id);
    }

    [Fact]
    public async void UpdateRoom_NoRoom_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();
        string roomName = fixture.Create<string>();

        Guid id = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = id, Name = roomName, Type = Context.DbRecords.RoomType.Economy });
        
        UpdateRoomRequest request = new()
        {
            Id = Guid.NewGuid(),
            Name = fixture.Create<string>(),
            Type = RoomType.Standard
        };

        //Act
        var response = await client.PutAsJsonAsync("/room/update", request);

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async void GetAvailableRooms_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();
        string roomName = fixture.Create<string>();

        Guid id = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        var addResponse = await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = id, Name = roomName, Type = RoomType.Economy });
        var roomResponse = await addResponse.Content.ReadFromJsonAsync<AddRoomResponse>();

        //Act
        var response = await client.GetAsync($"/room/getavailablerooms/{id}?type={RoomType.Economy}&startdate={DateTime.Today.AddDays(1).ToShortDateString()}&enddate={DateTime.Today.AddDays(2).ToShortDateString()}");
        var roomsResponse = await response.Content.ReadFromJsonAsync<GetAvailableRoomsResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(roomsResponse);
        Assert.NotNull(roomResponse);
        Assert.Equal(roomResponse.Id, roomsResponse.RoomIds.First());
    }

    [Fact]
    public async void GetAvailableRooms_OtherRoomType_Empty()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();
        string roomName = fixture.Create<string>();

        Guid id = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        var addResponse = await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = id, Name = roomName, Type = RoomType.Economy });
        var roomResponse = await addResponse.Content.ReadFromJsonAsync<AddRoomResponse>();

        //Act
        var response = await client.GetAsync($"/room/getavailablerooms/{id}?type={RoomType.Standard}&startdate={DateTime.Today.AddDays(1)}&enddate={DateTime.Today.AddDays(2)}");
        var roomsResponse = await response.Content.ReadFromJsonAsync<GetAvailableRoomsResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(roomsResponse);        
        Assert.Empty(roomsResponse.RoomIds);
    }

    [Fact]
    public async void GetAvailableRooms_Occupied_Empty()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();
        string roomName = fixture.Create<string>();

        Guid id = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = id });
        var addResponse = await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = id, Name = roomName, Type = RoomType.Economy });
        var roomResponse = await addResponse.Content.ReadFromJsonAsync<AddRoomResponse>();

        var startdate = DateTime.Today.AddDays(1);
        var enddate = DateTime.Today.AddDays(2);

        AddBookingRequest request = new()
        {
            EndDate = enddate,
            StartDate = startdate,
            Guests = 2,
            GuestName = "Guest",
            Type = RoomType.Economy,
            HotelId = id
        };

        await client.PostAsJsonAsync("/booking/add", request);

        //Act
        var response = await client.GetAsync($"/room/getavailablerooms/{id}?type={RoomType.Economy}&startdate={startdate}&enddate={enddate}");
        var roomsResponse = await response.Content.ReadFromJsonAsync<GetAvailableRoomsResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(roomsResponse);
        Assert.Empty(roomsResponse.RoomIds);
    }
}