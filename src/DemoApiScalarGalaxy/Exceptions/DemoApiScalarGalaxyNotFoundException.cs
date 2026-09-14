using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyNotFoundException : DemoApiScalarGalaxy4xxException
{
    public DemoApiScalarGalaxyNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
