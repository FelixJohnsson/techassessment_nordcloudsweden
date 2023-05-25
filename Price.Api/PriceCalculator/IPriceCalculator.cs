namespace Price.Api.PriceCalculator;

public interface IPriceCalculator
{
    public decimal BasePrice { get { return 500.0M; } }
    decimal GetPrice(PriceRequest request);
    bool Validate(PriceRequest request);
}
