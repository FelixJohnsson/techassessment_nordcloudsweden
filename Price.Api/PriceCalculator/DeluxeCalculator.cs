using FluentValidation;

namespace Price.Api.PriceCalculator;

public class DeluxeCalculator : IPriceCalculator
{
    private readonly StandardizedPrices _prices = new StandardizedPrices("Deluxe");
    public decimal GetPrice(PriceRequest request)
    {
        var nightprice = _prices.BasePrice * _prices.Multiplier + request.Guests * _prices.GuestPrice;

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
