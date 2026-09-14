using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyRateLimitException : DemoApiScalarGalaxy4xxException
{
    public DemoApiScalarGalaxyRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
