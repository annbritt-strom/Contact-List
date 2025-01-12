namespace Business.Services;

public static class GuidGeneratorService
{
    public static string Generate()
    {
        return Guid.NewGuid().ToString();
    }
}
