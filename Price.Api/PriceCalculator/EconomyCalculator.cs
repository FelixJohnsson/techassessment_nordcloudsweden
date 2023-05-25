using FluentValidation;

namespace Price.Api.PriceCalculator;

public class EconomyCalculator : IPriceCalculator
{
    private readonly decimal BasePrice = 500;
    private readonly decimal Multiplier = 0.7M;
    private readonly decimal GuestPrice = 50;

    public decimal GetPrice(PriceRequest request)
    {
        var nightprice = BasePrice * Multiplier + request.Guests * GuestPrice;

        return nightprice * request.Nights;
    }

    public bool Validate(PriceRequest request)
    {
        var validator = new EconomyValidator();

        var result = validator.Validate(request);

        return result.IsValid;
    }
}

public class EconomyValidator : AbstractValidator<PriceRequest>
{
    public EconomyValidator()
    {
        RuleFor(r => r.Guests).InclusiveBetween(1, 2);
        RuleFor(r => r.Nights).InclusiveBetween(1, 30);
    }
}
