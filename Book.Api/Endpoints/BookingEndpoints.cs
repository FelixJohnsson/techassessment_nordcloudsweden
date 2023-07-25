using Book.Api.Features.Bookings;
using MediatR;

namespace Book.Api.Endpoints;

public static class BookingEndpoints
{
    public static void AddBookingEndpoints(this WebApplication app)
    {
        app.MapGet("/booking/get/{id}", async (Guid id, IMediator mediator) => await mediator.Send(new GetBookingRequest { Id = id }));
        app.MapGet("/booking/getforhotel/{hotelid}", async (Guid hotelId, int? skip, int? take, DateTime? periodStart, DateTime? periodEnd, IMediator mediator) =>
        {
            GetBookingsForHotelRequest req = new()
            {
                HotelId = hotelId
            };

            if (skip is not null) { req.Skip = skip.Value; }
            if (take is not null) { req.Take = take.Value; }
            if (periodEnd is not null) { req.PeriodEnd = periodEnd.Value; }
            if (periodStart is not null) { req.PeriodStart = periodStart.Value; }

            return await mediator.Send(req);
        });
        app.MapPost("/booking/add", async (AddBookingRequest request, IMediator mediator) => await mediator.Send(request));
        app.MapPut("/booking/update", async (UpdateBookingRequest request, IMediator mediator) => await mediator.Send(request));
    }
}
