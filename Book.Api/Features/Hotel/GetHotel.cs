using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Hotel;

public class GetHotelRequestHandler : IRequestHandler<GetHotelRequest, GetHotelResponse>
{
    private readonly HotelContext _context;
    public GetHotelRequestHandler(HotelContext context)
    {
        _context = context;
    }

    public async Task<GetHotelResponse> Handle(GetHotelRequest request, CancellationToken cancellationToken)
    {
        HotelRecord hotel = await _context.Hotels.FirstAsync(h => h.Id == request.Id, cancellationToken);
                
        return new() { Id = hotel.Id };
    }
}

public class GetHotelValidator : AbstractValidator<GetHotelRequest>
{
    public GetHotelValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public class GetHotelRequest : IRequest<GetHotelResponse>
{
    public Guid Id { get; set; }
}

public class GetHotelResponse
{
    public Guid? Id { get; set; }
}