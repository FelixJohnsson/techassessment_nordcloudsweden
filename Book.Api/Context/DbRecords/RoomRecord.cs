namespace Book.Api.Context.DbRecords;

public record RoomRecord : ISoftDelete
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public RoomType Type { get; set; }
    public bool IsDeleted { get; set; }
    public Guid HotelId { get; set; }

    public virtual HotelRecord Hotel { get; set; } = new();
    public virtual List<BookingRecord> Bookings { get; set; } = new();
}

public enum RoomType
{
    Economy,
    Standard,
    Deluxe
}
