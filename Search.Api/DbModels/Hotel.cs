namespace Search.Api.DbModels;

public class Hotel
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Address Addrees { get; set; } = new();
    public IList<Room> Rooms { get; set; } = new List<Room>();
    public int EconomyRoomCount { get; set; }
    public int StandardRoomCount { get; set; }
    public int DeluxeRoomCount { get; set; }
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string? Street2 { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
