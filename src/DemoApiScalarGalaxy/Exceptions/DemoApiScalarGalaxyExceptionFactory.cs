using System.Net;

namespace DemoApiScalarGalaxy.Exceptions;

public class DemoApiScalarGalaxyExceptionFactory
{
    public static DemoApiScalarGalaxyApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    )
    {
        return (int)statusCode switch
        {
            400 => new DemoApiScalarGalaxyBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401 => new DemoApiScalarGalaxyUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403 => new DemoApiScalarGalaxyForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404 => new DemoApiScalarGalaxyNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422 => new DemoApiScalarGalaxyUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429 => new DemoApiScalarGalaxyRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499 => new DemoApiScalarGalaxy4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599 => new DemoApiScalarGalaxy5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ => new DemoApiScalarGalaxyUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
        };
    }
}
