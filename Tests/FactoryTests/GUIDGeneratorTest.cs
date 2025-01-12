using Business.Services;

namespace Tests.FactoryTests;

public class GUIDGeneratorTest
{
    [Fact]
    public void ShouldGenerateGuidAsString()
    {
        // Act
        var result = GuidGeneratorService.Generate();

        // Assert 
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out Guid guid));
    }
}
