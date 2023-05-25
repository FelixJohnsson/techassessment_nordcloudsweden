using Search.Api.DbModels;

namespace Search.Api.Models;

public record SearchHotelsResult
{
    public IEnumerable<Hotel> Hotels { get; set; } = new List<Hotel>();
    public int TotalCount { get; set; }
}
