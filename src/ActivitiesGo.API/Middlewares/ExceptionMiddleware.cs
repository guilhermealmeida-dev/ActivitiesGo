using System;
using System.Net;
using System.Text.Json;
using ActivitiesGo.Shared.Exceptions;

namespace ActivitiesGo.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException vex)
        {
            context.Response.StatusCode = (int)vex.StatusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = vex.Message,
                status = (int)vex.StatusCode,
                errors = vex.Errors
            };

            var json = System.Text.Json.JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
        catch (AppException ex)
        {
            context.Response.StatusCode = (int)ex.StatusCode;
            context.Response.ContentType = "application/json";
            var response = new { error = ex.Message };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var response = new { error = "Erro inesperado. Tente novamente mais tarde." };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
