namespace Book.Api.Context;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}
