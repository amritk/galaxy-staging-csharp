using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxy4xxException : DemoApiScalarGalaxyApiException
{
    public DemoApiScalarGalaxy4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
