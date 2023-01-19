using MissionStatistics.Domain.Exceptions;
using MissionStatistics.Domain.Models;

namespace MissionStatistics.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        var result = ex switch
        {
            NotFoundException => new ErrorDetails { StatusCode = StatusCodes.Status404NotFound, Message = ex.Message },
            _ => new ErrorDetails { StatusCode = StatusCodes.Status500InternalServerError, Message = "Somethong went wronge." }
        };

        context.Response.StatusCode = result.StatusCode;
        return context.Response.WriteAsync(result.ToString());
    }
}
