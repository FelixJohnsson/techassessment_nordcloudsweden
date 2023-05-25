using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Bookings;

public class UpdateBookingRequestHandler : IRequestHandler<UpdateBookingRequest, UpdateBookingResponse>
{
    private readonly HotelContext _context;
    public UpdateBookingRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<UpdateBookingResponse> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
    {
        BookingRecord booking = await _context.Bookings
            .Include(b => b.Room)
            .FirstAsync(b => b.Id == request.BookingId, cancellationToken);

        _context.Entry(booking).State = EntityState.Deleted;

        RoomRecord? room = await _context.Rooms
            .Include(r => r.Bookings)
            .Where(r => r.HotelId == booking.Room.HotelId
                        && r.Type == request.Type &&
                        !r.Bookings.Any(b => b.StartDate < request.EndDate
                                        && b.EndDate > request.StartDate))
            .FirstOrDefaultAsync(cancellationToken);

        _context.Entry(booking).State = EntityState.Unchanged;

        if (room is null)
        {
            throw new Exception("No room available");
        }

        booking.EndDate = request.EndDate.Value;
        booking.StartDate = request.StartDate.Value;
        booking.Guests = request.Guests;
        booking.GuestName = request.GuestName;

        booking.Room = room;
        
        await _context.SaveChangesAsync(cancellationToken);

        return new() { Id = booking.Id };
    }
}

public class UpdateBookingValidator : AbstractValidator<UpdateBookingRequest>
{
    public UpdateBookingValidator(HotelContext context)
    {
        RuleFor(x => x.BookingId).NotEmpty();
        RuleFor(x => x.BookingId).Must(id => context.Bookings.Any(h => h.Id == id));

        RuleFor(x => x.GuestName).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Guests).GreaterThan(0);
        RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today);
        RuleFor(x => x).Must(x => x.StartDate < x.EndDate);
    }
}

public class UpdateBookingRequest : IRequest<UpdateBookingResponse>
{
    public Guid BookingId { get; set; }
    public RoomType? Type { get; set; }
    public int Guests { get; set; }
    public string? GuestName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class UpdateBookingResponse
{
    public Guid Id { get; set; }
}
