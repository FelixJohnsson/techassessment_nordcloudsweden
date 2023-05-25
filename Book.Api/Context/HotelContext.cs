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
        builder.Entity<HotelRecord>().HasMany(e => e.Rooms)
            .WithOne(s => s.Hotel)
            .HasForeignKey(s => s.HotelId);

        builder.Entity<RoomRecord>()
            .Property(e => e.Name).HasMaxLength(32);
        builder.Entity<RoomRecord>()
            .Property(e => e.Type).IsRequired();
        builder.Entity<RoomRecord>().HasMany(e => e.Bookings)
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId);

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
