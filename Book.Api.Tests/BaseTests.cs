namespace Book.Api.Tests;
public class BaseTests
{
    public BaseTests()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
    }
}
