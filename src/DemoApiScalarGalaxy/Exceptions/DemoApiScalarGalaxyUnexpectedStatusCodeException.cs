using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyUnexpectedStatusCodeException : DemoApiScalarGalaxyApiException
{
    public DemoApiScalarGalaxyUnexpectedStatusCodeException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
