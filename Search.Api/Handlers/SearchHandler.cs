using Microsoft.AspNetCore.Mvc;
using Search.Api.DbModels;
using Search.Api.Models;
using Search.Api.Repository;

namespace Search.Api.Handlers;

public static class SearchHandler
{
    public static void RegisterSearchApis(this WebApplication app)
    {
        app.MapGet("/hotel/search", async (
            string term,
            int skip,
            int page,
            [FromServices] IUnitOfWork uof,
            CancellationToken token) =>
        {
            IEnumerable<Hotel> hotels = await uof.GetHotelRepository().FilterAsync(h => h.Name.ToLower().Contains(term.ToLower()), skip, page, token);
            int count = await uof.GetHotelRepository().CountAsync(h => h.Name.ToLower().Contains(term.ToLower()), token);

            return TypedResults.Ok(new SearchHotelsResult { Hotels = hotels, TotalCount = count });
        });
    }
}
