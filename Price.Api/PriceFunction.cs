using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Price.Api.PriceCalculator;
using System.Threading.Tasks;

namespace Price.Api;

public static class PriceFunction
{
    [FunctionName("Price")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "price/{roomtype:int}/{guests:int}/{nights:int}")] HttpRequest req,
        int roomType, int guests, int nights)
    {
        PriceRequest request = new() { RoomType = (RoomType)roomType, Guests = guests, Nights = nights };

        var calc = PriceCalculatorFactory.GetCalculator(request.RoomType);

        if (!calc.Validate(request))
            return new BadRequestObjectResult("Request is not valid");

        var price = calc.GetPrice(request);

        return new OkObjectResult(price);

    }
}
