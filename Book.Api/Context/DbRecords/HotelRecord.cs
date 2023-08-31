namespace Book.Api.Context.DbRecords;

public record HotelRecord : ISoftDelete
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public virtual List<RoomRecord> Rooms { get; set; } = new();
}
