using Book.Api.Features.Hotel;
using MediatR;

namespace Book.Api.Endpoints;

public static class HotelEndpoints
{
    public static void AddHotelsEndpoints(this WebApplication app)
    {
        app.MapGet("/hotel/get/{id}", async (Guid id, IMediator mediator) => await mediator.Send(new GetHotelRequest { Id = id }));
        app.MapPost("/hotel/add", async (AddHotelRequest request, IMediator mediator) => await mediator.Send(request));
        app.MapDelete("/hotel/delete/{id}", async (Guid id , IMediator mediator) => await mediator.Send(new DeleteHotelRequest() { Id = id }));
    }
}
