using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyUnprocessableEntityException : DemoApiScalarGalaxy4xxException
{
    public DemoApiScalarGalaxyUnprocessableEntityException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
