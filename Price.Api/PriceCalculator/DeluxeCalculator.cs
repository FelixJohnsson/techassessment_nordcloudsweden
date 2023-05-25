using FluentValidation;

namespace Price.Api.PriceCalculator;

public class DeluxeCalculator : IPriceCalculator
{
    private readonly decimal BasePrice = 500;
    private readonly decimal Multiplier = 1.3M;
    private readonly decimal GuestPrice = 70;

    public decimal GetPrice(PriceRequest request)
    {
        var nightprice = BasePrice * Multiplier + request.Guests * GuestPrice;

        return nightprice * request.Nights;
    }

    public bool Validate(PriceRequest request)
    {
        var validator = new DeluxeValidator();

        var result = validator.Validate(request);

        return result.IsValid;
    }
}

public class DeluxeValidator : AbstractValidator<PriceRequest>
{
    public DeluxeValidator()
    {
        RuleFor(r => r.Guests).InclusiveBetween(1, 4);
        RuleFor(r => r.Nights).InclusiveBetween(1, 30);
    }
}
