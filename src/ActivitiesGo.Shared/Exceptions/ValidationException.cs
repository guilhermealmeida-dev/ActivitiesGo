using System;
using System.Net;
namespace ActivitiesGo.Shared.Exceptions;

public class ValidationException(
    IDictionary<string, string[]> errors,
    string message = "Informe os campos obrigatórios corretamente.",
    HttpStatusCode statusCode = HttpStatusCode.BadRequest) : AppException(message, statusCode)
{
    public IDictionary<string, string[]> Errors { get; } = errors;
}
