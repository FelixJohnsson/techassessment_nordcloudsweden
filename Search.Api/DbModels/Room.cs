namespace Search.Api.DbModels;

public class Room
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public RoomType RoomType { get; set; }
}
