using FluentValidation;

namespace Price.Api.PriceCalculator;

public class EconomyCalculator : IPriceCalculator
{
    private readonly StandardizedPrices _prices = new StandardizedPrices("Economy");
    public decimal GetPrice(PriceRequest request)
    {
        var nightprice = _prices.BasePrice * _prices.Multiplier + request.Guests * _prices.GuestPrice;

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
