using System;

namespace Price.Api.PriceCalculator;

public static class PriceCalculatorFactory
{
    public static IPriceCalculator GetCalculator(RoomType roomType)
    {
        return roomType switch
        {
            RoomType.Economy => new EconomyCalculator(),
            RoomType.Standard => new StandardCalculator(),
            RoomType.Deluxe => new DeluxeCalculator(),
            _ => throw new NotImplementedException("RoomType not implemented"),
        };
    }
}
