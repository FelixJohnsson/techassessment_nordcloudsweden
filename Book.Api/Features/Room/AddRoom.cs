using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Room;

public class AddRoomRequestHandler : IRequestHandler<AddRoomRequest, AddRoomResponse>
{
    private readonly HotelContext _context;
    public AddRoomRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<AddRoomResponse> Handle(AddRoomRequest request, CancellationToken cancellationToken)
    {
        HotelRecord hotel = await _context.Hotels.FirstAsync(h => h.Id == request.HotelId, cancellationToken);

        RoomRecord room = new()
        {
            Name = request.Name,
            Type = request.Type is not null ? request.Type.Value : throw new ArgumentNullException("RoomType can't be null", nameof(request.Type)),
            Hotel = hotel
        };

        await _context.Rooms.AddAsync(room, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new() { Id = room.Id };
    }
}

public class AddRoomValidator : AbstractValidator<AddRoomRequest> 
{
    public AddRoomValidator(HotelContext context)
    {
        RuleFor(x => x.HotelId).NotEmpty();
        RuleFor(x => x.HotelId).Must(id => context.Hotels.Any(h => h.Id == id));

        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Type).IsInEnum();
    }
}

public class AddRoomRequest : IRequest<AddRoomResponse>
{
    public string Name { get; set; } = string.Empty;
    public RoomType? Type { get; set; }
    public Guid? HotelId { get; set; }
}

public class AddRoomResponse
{
    public Guid Id { get; set; }
}
