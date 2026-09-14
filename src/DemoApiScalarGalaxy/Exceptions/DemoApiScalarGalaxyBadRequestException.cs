using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyBadRequestException : DemoApiScalarGalaxy4xxException
{
    public DemoApiScalarGalaxyBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
