using System;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyInvalidDataException : DemoApiScalarGalaxyException
{
    public DemoApiScalarGalaxyInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
