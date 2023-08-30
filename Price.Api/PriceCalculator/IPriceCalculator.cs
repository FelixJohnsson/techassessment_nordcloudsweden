namespace Price.Api.PriceCalculator;

public interface IPriceCalculator
{
    decimal GetPrice(PriceRequest request);
    bool Validate(PriceRequest request);
}

public class StandardizedPrices
{
    public decimal BasePrice { get; }
    public decimal Multiplier { get; }
    public decimal GuestPrice { get; }

    public StandardizedPrices(string type)
    {
        BasePrice = 500.0M;

        if(type == "Economy"){
            Multiplier = 0.7M;
            GuestPrice = 50M;
        }
        else if(type == "Deluxe"){
            Multiplier = 1.3M;
            GuestPrice = 70M;
        }
        else if(type == "Standard"){
            Multiplier = 1.0M;
            GuestPrice = 60M;
        }
    }
}
