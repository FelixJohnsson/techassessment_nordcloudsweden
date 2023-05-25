using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Bookings;

public class AddBookingRequestHandler : IRequestHandler<AddBookingRequest, AddBookingResponse>
{
    private readonly HotelContext _context;
    public AddBookingRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<AddBookingResponse> Handle(AddBookingRequest request, CancellationToken cancellationToken)
    {
        RoomRecord? room = await _context.Rooms.Include(r => r.Bookings)
            .Where(r => r.HotelId == request.HotelId
                        && r.Type == request.Type &&
                        !r.Bookings.Any(b => b.StartDate < request.EndDate
                                        && b.EndDate > request.StartDate))
            .FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("No room available");

        BookingRecord booking = new()
        {
            EndDate = request.EndDate.Value,
            StartDate = request.StartDate.Value,
            GuestName = request.GuestName,
            Guests = request.Guests,
            Room = room,
        };

        await _context.Bookings.AddAsync(booking, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new() { Id = booking.Id };
    }
}

public class AddBookingValidator : AbstractValidator<AddBookingRequest>
{
    public AddBookingValidator(HotelContext context)
    {
        RuleFor(x => x.HotelId).NotEmpty();
        RuleFor(x => x.HotelId).Must(id => context.Hotels.Any(h => h.Id == id));

        RuleFor(x => x.GuestName).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Guests).GreaterThan(0);
        RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today);
        RuleFor(x => x).Must(x => x.StartDate < x.EndDate).WithName("Period");
    }
}

public class AddBookingRequest : IRequest<AddBookingResponse>
{
    public RoomType? Type { get; set; }
    public Guid HotelId { get; set; }
    public int Guests { get; set; }
    public string? GuestName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class AddBookingResponse
{
    public Guid Id { get; set; }
}
