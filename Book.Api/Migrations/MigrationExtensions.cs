using Book.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Migrations;

public static class MigrationExtensions
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (IServiceScope scope = webApp.Services.CreateScope())
        {
            using HotelContext appContext = scope.ServiceProvider.GetRequiredService<HotelContext>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                //Log errors or do anything you think it's needed
                throw;
            }
        }
        return webApp;
    }
}
