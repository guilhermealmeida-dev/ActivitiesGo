using System;
using System.Net;

namespace ActivitiesGo.Shared.Exceptions;

public class NotFoundExeption : AppException
{
    public NotFoundExeption(string message) : base(message, HttpStatusCode.NotFound)
    {
    }
}
