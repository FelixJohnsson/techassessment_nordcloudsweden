using FluentValidation;

namespace Price.Api.PriceCalculator;

public class StandardCalculator : IPriceCalculator
{
    private readonly decimal BasePrice = 500;
    private readonly decimal GuestPrice = 60;

    public decimal GetPrice(PriceRequest request)
    {
        var nightprice = BasePrice + request.Guests * GuestPrice;

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
