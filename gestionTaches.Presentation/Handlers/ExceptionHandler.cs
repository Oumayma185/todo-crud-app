using gestionTaches.Contracts.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace gestionTaches.Presentation.Handlers;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemsDetails = CreateProblemDetails(exception);
        httpContext.Response.StatusCode=problemsDetails.Status ?? StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemsDetails,cancellationToken);
        return true;
    }

    private static ProblemDetails CreateProblemDetails(Exception exception)
    {
        ProblemDetails problemDetails = exception switch
        {
            NotFoundException notFoundEx => CreateProblemDetails(
                StatusCodes.Status404NotFound,
                "Not found",
                notFoundEx.Message),
        
            CustomValidationException validationEx => CreateProblemDetails(
                StatusCodes.Status400BadRequest,
                "Validation Error",
                validationEx.Message),
        
            _ => CreateProblemDetails(
                StatusCodes.Status500InternalServerError,
                "Internal Server Error",
                "Une erreur inattendue, veuillez réessayer plus tard !")
        };
        if (exception is CustomValidationException customValidationEx)
        {
            problemDetails.Extensions.Add("Errors", customValidationEx.ValidationErrors);
        }
        return problemDetails;
    }

    private static ProblemDetails CreateProblemDetails(int status, string title, string detail)
    {
        return new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail
        };

    }
}