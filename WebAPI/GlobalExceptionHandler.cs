using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var logger = httpContext
            .RequestServices
            .GetRequiredService<ILogger<GlobalExceptionHandler>>();

        var statusCode = exception switch
        {
            ValidationException _ => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var isDevelopment = httpContext.RequestServices
            .GetRequiredService<IWebHostEnvironment>()
            .IsDevelopment();

        // var detail = isDevelopment ? exception.ToString() : "An unexpected error occurred";

        logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Title = statusCode == StatusCodes.Status500InternalServerError
                ? "An error occurred"
                : exception.GetType().Name,
            Detail = exception.ToString(),
            Status = statusCode
        };

        if (exception is ValidationException validationException)
        {
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Title = "Validation error";
            problemDetails.Extensions.Add("errors", validationException.Errors);
        }

        httpContext.Response.ContentType = "application/problem+json";

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
