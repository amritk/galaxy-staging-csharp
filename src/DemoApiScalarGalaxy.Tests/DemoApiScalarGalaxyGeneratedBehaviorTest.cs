using System.Net;
using DemoApiScalarGalaxy.Exceptions;
using Xunit;

namespace DemoApiScalarGalaxy.Tests;

public sealed class DemoApiScalarGalaxyGeneratedBehaviorTest
{
    [Fact]
    public void ExceptionFactoryClassifiesStatusCodes()
    {
        var exception = DemoApiScalarGalaxyExceptionFactory.CreateApiException(
            HttpStatusCode.BadRequest,
            "{\"message\":\"bad request\"}"
        );

        Assert.IsType<DemoApiScalarGalaxyBadRequestException>(exception);
        Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        Assert.Contains("bad request", exception.Message);
    }

    [Fact]
    public void ModelsPreserveWireNames()
    {
        var model = new global::DemoApiScalarGalaxy.Models.Planets.Atmosphere
        {
            Compound = "smoke",
        };

        Assert.Contains("compound", model.RawData.Keys);
    }
}
