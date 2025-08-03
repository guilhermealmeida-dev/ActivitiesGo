using System.Net;

namespace ActivitiesGo.Shared.Exceptions;

public class AppException(string message, HttpStatusCode statusCode ) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
