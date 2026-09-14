using System;
using System.Net.Http;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyIOException : DemoApiScalarGalaxyException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public DemoApiScalarGalaxyIOException(
        string message,
        HttpRequestException? innerException = null
    )
        : base(message, innerException) { }
}
