using Book.Api.Context;
using Book.Api.Context.DbRecords;
using FluentValidation;
using MediatR;

namespace Book.Api.Features.Hotel;

public class DeleteHotel
{
    public class DeleteHotelRequestHandler : IRequestHandler<DeleteHotelRequest, DeleteHotelResponse>
    {
        private readonly HotelContext _context;
        public DeleteHotelRequestHandler(HotelContext context)
        {
            _context = context;
        }

        public async Task<DeleteHotelResponse> Handle(DeleteHotelRequest request, CancellationToken cancellationToken)
        {
            _context.Remove<HotelRecord>(new() { Id = request.Id });

            await _context.SaveChangesAsync(cancellationToken);

            return new() { Id = request.Id };
        }
    }
}

public class DeleteHotelValidator : AbstractValidator<DeleteHotelRequest>
{
    public DeleteHotelValidator(HotelContext context)
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Id).Must(id => context.Hotels.Any(h => h.Id == id));
    }
}

public class DeleteHotelRequest : IRequest<DeleteHotelResponse>
{
    public Guid Id { get; set; }
}

public class DeleteHotelResponse
{
    public Guid Id { get; set; }
}


