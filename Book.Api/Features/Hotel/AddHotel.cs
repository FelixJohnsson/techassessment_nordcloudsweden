using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;

namespace Book.Api.Features.Hotel;

public class AddHotelRequestHandler : IRequestHandler<AddHotelRequest, AddHotelResponse>
{
    private readonly HotelContext _context;
    public AddHotelRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<AddHotelResponse> Handle(AddHotelRequest request, CancellationToken cancellationToken)
    {
        HotelRecord hotel = new();

        if(request.Id is not null) { hotel.Id = request.Id.Value; }

        await _context.Hotels.AddAsync(hotel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new() { Id = hotel.Id };
    }
}

public class AddHotelValidator : AbstractValidator<AddHotelRequest> { }

public class AddHotelRequest : IRequest<AddHotelResponse>
{
    public Guid? Id { get; set; }

}

public class AddHotelResponse
{
    public Guid Id { get; set; }
}
