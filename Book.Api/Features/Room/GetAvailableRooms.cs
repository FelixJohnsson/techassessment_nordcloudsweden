using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Room;

public class GetAvailableRoomsRequestHandler : IRequestHandler<GetAvailableRoomsRequest, GetAvailableRoomsResponse>
{
    private readonly HotelContext _context;
    public GetAvailableRoomsRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<GetAvailableRoomsResponse> Handle(GetAvailableRoomsRequest request, CancellationToken cancellationToken)
    {
        List<Guid> rooms = await _context.Rooms
            .Include(r => r.Bookings)
            .Where(r => r.HotelId == request.HotelId
                        && r.Type == request.Type &&
                        !r.Bookings.Any(b => b.StartDate < request.EndDate
                                         && b.EndDate > request.StartDate))
            .Select(r => r.Id)
            .ToListAsync(cancellationToken);

        return new() { RoomIds = rooms };
    }
}

public class GetAvailableRoomsValidator : AbstractValidator<GetAvailableRoomsRequest>
{
    public GetAvailableRoomsValidator(HotelContext context)
    {
        RuleFor(x => x.HotelId).NotEmpty();
        RuleFor(x => x.HotelId).Must(id => context.Hotels.Any(h => h.Id == id));

        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today);
        RuleFor(x => x).Must(x => x.StartDate < x.EndDate);
    }
}

public class GetAvailableRoomsRequest : IRequest<GetAvailableRoomsResponse>
{
    public Guid HotelId { get; set; }
    public RoomType? Type { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class GetAvailableRoomsResponse
{
    public List<Guid> RoomIds { get; set; } = new();
}
