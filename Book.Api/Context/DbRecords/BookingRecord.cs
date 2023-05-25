namespace Book.Api.Context.DbRecords;

public record BookingRecord : ISoftDelete
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Guests { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public Guid RoomId { get; set; }

    public int Nights { get { return (EndDate - StartDate).Days; } }

    public virtual RoomRecord Room { get; set; } = null!;
}
