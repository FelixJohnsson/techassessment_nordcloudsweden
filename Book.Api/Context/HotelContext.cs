using Book.Api.Context.DbRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;

namespace Book.Api.Context;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var hotel1Id = Guid.NewGuid();
        var hotel2Id = Guid.NewGuid();
        var hotel3Id = Guid.NewGuid();

        var hotel1Name = "Stockholm Hilton";
        var hotel2Name = "London Ritz";
        var hotel3Name = "Madrid Sheraton";

        var room101Id = Guid.NewGuid();
        var room3002Id = Guid.NewGuid();
        var roomAId = Guid.NewGuid();

        builder.Entity<HotelRecord>().HasMany(e => e.Rooms)
            .WithOne(s => s.Hotel)
            .HasForeignKey(s => s.HotelId);

        builder.Entity<HotelRecord>().HasData(
            new HotelRecord { Id = hotel1Id, Name = hotel1Name },
            new HotelRecord { Id = hotel2Id, Name = hotel2Name },
            new HotelRecord { Id = hotel3Id, Name = hotel3Name }
            );

        builder.Entity<RoomRecord>()
            .Property(e => e.Name).HasMaxLength(32);
        builder.Entity<RoomRecord>()
            .Property(e => e.Type).IsRequired();
        builder.Entity<RoomRecord>().HasMany(e => e.Bookings)
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId);

        builder.Entity<RoomRecord>().HasData(
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "101", Id = room101Id },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "102" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "103" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "104" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "105" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "106" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Economy, Name = "107" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "201" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "202" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "203" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "204" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "205" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "206" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "302" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "303" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "304" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "305" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Standard, Name = "306" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "401" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "402" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "403" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "404" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "501" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "502" },
            new RoomRecord { HotelId = hotel1Id, Type = RoomType.Deluxe, Name = "503" },

            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "1001" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "1002" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "1003" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "1004" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "2001" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "2002" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "2003" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "2004" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "2005" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "2006" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "3001" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "3002", Id = room3002Id },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "3003" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "3004" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Economy, Name = "3005" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Standard, Name = "3006" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Deluxe, Name = "4001" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Deluxe, Name = "4002" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Deluxe, Name = "4003" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Deluxe, Name = "5001" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Deluxe, Name = "5002" },
            new RoomRecord { HotelId = hotel2Id, Type = RoomType.Deluxe, Name = "5003" },

            new RoomRecord { HotelId = hotel3Id, Type = RoomType.Deluxe, Name = "A", Id = roomAId },
            new RoomRecord { HotelId = hotel3Id, Type = RoomType.Deluxe, Name = "B" },
            new RoomRecord { HotelId = hotel3Id, Type = RoomType.Deluxe, Name = "C" },
            new RoomRecord { HotelId = hotel3Id, Type = RoomType.Standard, Name = "D" },
            new RoomRecord { HotelId = hotel3Id, Type = RoomType.Standard, Name = "E" },
            new RoomRecord { HotelId = hotel3Id, Type = RoomType.Standard, Name = "F" }
            );

        builder.Entity<BookingRecord>()
            .Property(e => e.Guests).IsRequired();
        builder.Entity<BookingRecord>()
            .Property(e => e.GuestName).HasMaxLength(128);
        builder.Entity<BookingRecord>()
            .Property(e => e.StartDate).IsRequired();
        builder.Entity<BookingRecord>()
            .Property(e => e.EndDate).IsRequired();
        builder.Entity<BookingRecord>()
            .Ignore(b => b.Nights);

        builder.Entity<BookingRecord>().HasData(

            new BookingRecord { RoomId = room101Id, GuestName = "John Smith", Guests = 2, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.AddDays(3).Date },
            new BookingRecord { RoomId = room101Id, GuestName = "Jane Doe", Guests = 2, StartDate = DateTime.Now.AddDays(3).Date, EndDate = DateTime.Now.AddDays(5).Date },
            new BookingRecord { RoomId = room101Id, GuestName = "Peter McAllister", Guests = 2, StartDate = DateTime.Now.AddDays(6).Date, EndDate = DateTime.Now.AddDays(7).Date },

            new BookingRecord { RoomId = room3002Id, GuestName = "Jane Austen", Guests = 3, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.AddDays(2).Date },
            new BookingRecord { RoomId = room3002Id, GuestName = "Edgar Allan Poe", Guests = 1, StartDate = DateTime.Now.AddDays(3).Date, EndDate = DateTime.Now.AddDays(4).Date },
            new BookingRecord { RoomId = room3002Id, GuestName = "Ernst Hemingway", Guests = 2, StartDate = DateTime.Now.AddDays(4).Date, EndDate = DateTime.Now.AddDays(7).Date },

            new BookingRecord { RoomId = roomAId, GuestName = "Humprey Bogart", Guests = 2, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.AddDays(7).Date },
            new BookingRecord { RoomId = roomAId, GuestName = "Harrison Ford", Guests = 4, StartDate = DateTime.Now.AddDays(10).Date, EndDate = DateTime.Now.AddDays(12).Date },
            new BookingRecord { RoomId = roomAId, GuestName = "Tom Hanks", Guests = 2, StartDate = DateTime.Now.AddDays(16).Date, EndDate = DateTime.Now.AddDays(20).Date }
            );

        foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }

        base.OnModelCreating(builder);

        // Disable cascade delete for everything, throw an exception instead - always to force control
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
    public override int SaveChanges()
    {
        CancelDeletionForSoftDelete();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        CancelDeletionForSoftDelete();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected virtual void CancelDeletionForSoftDelete()
    {
        foreach (var entry in ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted))
        {
            if (entry.Entity is not ISoftDelete softDeleteEntity)
            {
                return;
            }

            entry.Reload();
            entry.State = EntityState.Modified;
            softDeleteEntity.IsDeleted = true;
        }
    }

    public EntityEntry<T> UpdateFields<T>(T entity, params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var dbEntry = Entry(entity);
        foreach (var includeProperty in includeProperties)
        {
            dbEntry.Property(includeProperty).IsModified = true;
        }

        return dbEntry;
    }

    public void UpdateFields<T>(List<T> entities, params Expression<Func<T, object>>[] includesProperties) where T : class
    {
        foreach (T entity in entities)
        {
            UpdateFields(entity, includesProperties);
        }
    }

    public DbSet<HotelRecord> Hotels { get; set; }
    public DbSet<RoomRecord> Rooms { get; set; }
    public DbSet<BookingRecord> Bookings { get; set; }
}
