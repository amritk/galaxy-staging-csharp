using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyUnauthorizedException : DemoApiScalarGalaxy4xxException
{
    public DemoApiScalarGalaxyUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
