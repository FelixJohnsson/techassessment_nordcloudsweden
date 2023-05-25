using Microsoft.EntityFrameworkCore;
using Search.Api.DbModels;

namespace Search.Api.Repository
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .ToContainer("Hotels");

            modelBuilder.Entity<Hotel>().OwnsOne(
            o => o.Addrees,
            sa =>
            {
                sa.ToJsonProperty("Address");
            });
        }
    }
}
