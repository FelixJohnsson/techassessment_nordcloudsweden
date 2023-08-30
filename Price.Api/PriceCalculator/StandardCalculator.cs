using FluentValidation;

namespace Price.Api.PriceCalculator;

public class StandardCalculator : IPriceCalculator
{
    private readonly StandardizedPrices _prices = new StandardizedPrices("Standard");
    public decimal GetPrice(PriceRequest request)
    {
        var nightprice = _prices.BasePrice * _prices.Multiplier + request.Guests * _prices.GuestPrice;

        return nightprice * request.Nights;
    }

    public bool Validate(PriceRequest request)
    {
        var validator = new StanardValidator();

        var result = validator.Validate(request);

        return result.IsValid;
    }
}

public class StanardValidator : AbstractValidator<PriceRequest>
{
    public StanardValidator()
    {
        RuleFor(r => r.Guests).InclusiveBetween(1, 3);
        RuleFor(r => r.Nights).InclusiveBetween(1, 30);
    }
}
