using System;
using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyException : Exception
{
    public DemoApiScalarGalaxyException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected DemoApiScalarGalaxyException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
