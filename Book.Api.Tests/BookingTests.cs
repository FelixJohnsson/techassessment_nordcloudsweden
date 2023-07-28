using System.Net.Http.Json;
using System.Net;
using Xunit;
using Book.Api.Features.Hotel;
using Book.Api.Features.Room;
using AutoFixture;
using Book.Api.Context.DbRecords;
using Book.Api.Features.Bookings;

namespace Book.Api.Tests;

public class BookingTests : BaseTests
{
    public BookingTests() : base()
    {   
    }

    [Fact]
    public async void AddBooking_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });
        await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = hotelId, Name = "Room 1", Type = RoomType.Economy });

        AddBookingRequest request = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(1),
            Guests = 2,
            GuestName = fixture.Create<string>()
        };

        //Act
        var response = await client.PostAsJsonAsync("/booking/add", request);
        var addBookingResponse = await response.Content.ReadFromJsonAsync<AddBookingResponse>();

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(addBookingResponse?.Id);
    }

    [Fact]
    public async void AddBooking_WrongPeriod_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });

        AddBookingRequest request = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(3),
            Guests = 2,
            GuestName = fixture.Create<string>()
        };

        //Act
        var response = await client.PostAsJsonAsync("/booking/add", request);

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async void AddBooking_ZeroGuests_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });

        AddBookingRequest request = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(1),
            Guests = 0,
            GuestName = fixture.Create<string>()
        };

        //Act
        var response = await client.PostAsJsonAsync("/booking/add", request);

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async void AddBooking_NoHotel_ServerError()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();

        AddBookingRequest request = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(1),
            Guests = 2,
            GuestName = fixture.Create<string>()
        };

        //Act
        var response = await client.PostAsJsonAsync("/booking/add", request);

        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async void GetBooking_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });
        await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = hotelId, Name = "Room 1", Type = RoomType.Economy });

        var guestName = fixture.Create<string>();

        AddBookingRequest request = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(1),
            Guests = 2,
            GuestName = guestName
        };

        var addResponse = await client.PostAsJsonAsync("/booking/add", request);
        var addBookingResponse = await addResponse.Content.ReadFromJsonAsync<AddBookingResponse>();
        Assert.NotNull(addBookingResponse?.Id);

        //Act
        var response = await client.GetAsync($"/booking/get/{addBookingResponse.Id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var getResponse = await response.Content.ReadFromJsonAsync<GetBookingResponse>();

        //Assert        
        Assert.NotNull(getResponse?.Id);
        Assert.Equal(1, getResponse.Nights);
        Assert.Equal(DateTime.Today.AddDays(1), getResponse.ArriveDate);        
        Assert.Equal(guestName, getResponse.GuestName);
    }

    [Fact]
    public async void UpdateBooking_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });
        await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = hotelId, Name = "Room 1", Type = RoomType.Economy });
        await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = hotelId, Name = "Room 2", Type = RoomType.Standard });

        var guestName = fixture.Create<string>();

        AddBookingRequest addRequest = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(1),
            Guests = 2,
            GuestName = guestName
        };

        var addResponse = await client.PostAsJsonAsync("/booking/add", addRequest);
        var addBookingResponse = await addResponse.Content.ReadFromJsonAsync<AddBookingResponse>();
        Assert.NotNull(addBookingResponse?.Id);

        var newGuestName = fixture.Create<string>();

        UpdateBookingRequest request = new()
        {
            BookingId = addBookingResponse.Id,
            Type = RoomType.Standard,
            EndDate = DateTime.Today.AddDays(4),
            StartDate = DateTime.Today.AddDays(2),
            Guests = 2,
            GuestName = newGuestName
        };

        //Act
        var response =  await client.PutAsJsonAsync("/booking/update", request);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);        
    }

    [Fact]
    public async void GetBookingForHotel_Ok()
    {
        //Assign
        await using var app = new TestBookApiApp();
        var client = app.CreateClient();

        var fixture = new Fixture();

        Guid hotelId = Guid.NewGuid();
        await client.PostAsJsonAsync("/hotel/add", new AddHotelRequest { Id = hotelId });
        await client.PostAsJsonAsync("/room/add", new AddRoomRequest { HotelId = hotelId, Name = "Room 1", Type = RoomType.Economy });

        var guestName = fixture.Create<string>();

        AddBookingRequest request = new()
        {
            HotelId = hotelId,
            Type = RoomType.Economy,
            EndDate = DateTime.Today.AddDays(2),
            StartDate = DateTime.Today.AddDays(1),
            Guests = 2,
            GuestName = guestName
        };

        await client.PostAsJsonAsync("/booking/add", request);

        AddBookingRequest request2 = new()
        {
            HotelId = hotelId,
            Type = RoomType.Standard,
            EndDate = DateTime.Today.AddDays(10),
            StartDate = DateTime.Today.AddDays(8),
            Guests = 2,
            GuestName = fixture.Create<string>()
        };

        await client.PostAsJsonAsync("/booking/add", request);


        //Act
        var response = await client.GetAsync($"/booking/getforhotel/{hotelId}");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}