using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Book.Api.Features.Bookings;

public class GetBookingsForHotelRequestHandler : IRequestHandler<GetBookingsForHotelRequest, GetBookingsForHotelResponse>
{
    private readonly HotelContext _context;
    public GetBookingsForHotelRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<GetBookingsForHotelResponse> Handle(GetBookingsForHotelRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<BookingRecord, bool>> filter = b => b.Room.HotelId == request.HotelId && b.StartDate >= request.PeriodStart & b.StartDate < request.PeriodEnd;

        List<Booking> bookings = await _context.Bookings
            .Include(b => b.Room)
            .Where(filter)
            .Skip(request.Skip)
            .Take(request.Take)
            .OrderBy(b => b.StartDate)
            .Select(b => new Booking
            {
                ArriveDate = b.StartDate,
                GuestName = b.GuestName,
                Id = b.Id,
                Nights = b.Nights
            })
            .ToListAsync(cancellationToken);

        int count = await _context.Bookings
            .Include(b => b.Room)
            .CountAsync(filter, cancellationToken);

        return new()
        {
            Bookings = bookings,
            TotalResults = count
        };
    }
}

public class GetBookingsForHotelValidator : AbstractValidator<GetBookingsForHotelRequest>
{
    public GetBookingsForHotelValidator()
    {
        RuleFor(x => x.HotelId).NotEmpty();
        RuleFor(x => x.Take).GreaterThan(0);
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
    }
}

public class GetBookingsForHotelRequest : IRequest<GetBookingsForHotelResponse>
{
    public Guid HotelId { get; set; }
    public DateTime PeriodStart { get; set; } = DateTime.Today;
    public DateTime PeriodEnd { get; set; } = DateTime.Today.AddMonths(1);
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}

public class GetBookingsForHotelResponse
{
    public List<Booking> Bookings { get; set; } = new();
    public int TotalResults { get; set; }
}

public record Booking
{
    public Guid Id { get; set; }
    public int Nights { get; set; }
    public DateTime ArriveDate { get; set; }
    public string GuestName { get; set; } = string.Empty;
}