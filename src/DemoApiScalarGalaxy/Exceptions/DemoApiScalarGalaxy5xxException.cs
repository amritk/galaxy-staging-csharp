using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxy5xxException : DemoApiScalarGalaxyApiException
{
    public DemoApiScalarGalaxy5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
