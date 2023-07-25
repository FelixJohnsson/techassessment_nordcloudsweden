using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Bookings;

public class GetBookingRequestHandler : IRequestHandler<GetBookingRequest, GetBookingResponse>
{
    private readonly HotelContext _context;
    public GetBookingRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<GetBookingResponse> Handle(GetBookingRequest request, CancellationToken cancellationToken)
    {
        BookingRecord Booking = await _context.Bookings.Include(b => b.Room).FirstAsync(h => h.Id == request.Id, cancellationToken);

        return new()
        {
            Id = Booking.Id,
            GuestName = Booking.GuestName,
            Nights = Booking.Nights,
            RoomType = Booking.Room?.Type ?? RoomType.Economy,
            ArriveDate = Booking.StartDate
        };
    }
}

public class GetBookingValidator : AbstractValidator<GetBookingRequest>
{
    public GetBookingValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public class GetBookingRequest : IRequest<GetBookingResponse>
{
    public Guid Id { get; set; }
}

public class GetBookingResponse
{
    public Guid Id { get; set; }
    public RoomType RoomType { get; set; }
    public int Nights { get; set; }
    public DateTime ArriveDate { get; set; }
    public string GuestName { get; set; } = string.Empty;
}
