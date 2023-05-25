using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;

namespace Book.Api.Features.Room;

public class UpdateRoomRequestHandler : IRequestHandler<UpdateRoomRequest, UpdateRoomResponse>
{
    private readonly HotelContext _context;
    public UpdateRoomRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<UpdateRoomResponse> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
        RoomRecord room = new()
        {
            Id = request.Id,
            Name = request.Name,
            Type = request.Type is not null ? request.Type.Value : throw new ArgumentNullException("RoomType can't be null", nameof(request.Type)),            
        };

        _context.UpdateFields(room, r => r.Name, r => r.Type);
        await _context.SaveChangesAsync(cancellationToken);

        return new() { Id = room.Id };
    }
}

public class UpdateRoomValidator : AbstractValidator<UpdateRoomRequest>
{
    public UpdateRoomValidator(HotelContext context)
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Id).Must(id => context.Rooms.Any(h => h.Id == id));

        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
    }
}

public class UpdateRoomRequest : IRequest<UpdateRoomResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public RoomType? Type { get; set; }
}

public class UpdateRoomResponse
{
    public Guid Id { get; set; }
}
