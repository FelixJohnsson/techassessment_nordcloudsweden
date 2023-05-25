namespace Price.Api;

public class PriceRequest
{
    public RoomType RoomType { get; set; }
    public int Guests { get; set; }
    public int Nights { get; set; }
}
