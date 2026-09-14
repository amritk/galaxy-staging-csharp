using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyForbiddenException : DemoApiScalarGalaxy4xxException
{
    public DemoApiScalarGalaxyForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
