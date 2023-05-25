using Book.Api.Context.DbRecords;
using Book.Api.Features.Room;
using MediatR;

namespace Book.Api.Endpoints;

public static class RoomEndpoints
{
    public static void AddRoomEndpoints(this WebApplication app)
    {
        app.MapPost("/room/add", async (AddRoomRequest request, IMediator mediator) => await mediator.Send(request));
        app.MapPut("/room/update", async (UpdateRoomRequest request, IMediator mediator) => await mediator.Send(request));
        app.MapGet("/room/getavailablerooms/{hotelid}", async (Guid hotelId, RoomType type, DateTime startDate, DateTime endDate, IMediator mediator) => 
            await mediator.Send(new GetAvailableRoomsRequest { EndDate = endDate, HotelId = hotelId, StartDate = startDate, Type = type }));

    }
}
