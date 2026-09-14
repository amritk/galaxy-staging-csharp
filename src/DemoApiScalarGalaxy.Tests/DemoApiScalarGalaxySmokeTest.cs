using Xunit;

namespace DemoApiScalarGalaxy.Tests;

public sealed class DemoApiScalarGalaxySmokeTest
{
    [Fact]
    public void ConstructsClient()
    {
        Assert.NotNull(new DemoApiScalarGalaxyClient());
    }
}
