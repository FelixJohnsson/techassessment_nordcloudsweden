namespace Book.Api.Context.DbRecords;

public record HotelRecord : ISoftDelete
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsDeleted { get; set; }
    public virtual List<RoomRecord> Rooms { get; set; } = new();
}
