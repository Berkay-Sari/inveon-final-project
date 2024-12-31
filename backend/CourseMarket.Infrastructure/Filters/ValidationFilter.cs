using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;
using CourseMarket.Application.Wrappers;

namespace CourseMarket.Infrastructure.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid)
        {
            await next();
            return;
        }

        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Any())
            .ToDictionary(
                ms => ms.Key,
                ms => ms.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var problemDetails = new ProblemDetails
        {
            Title = "Validation Error",
            Detail = "One or more validation errors occurred.",
            Status = (int)HttpStatusCode.BadRequest,
            Extensions = { ["errors"] = errors }
        };

        context.Result = new ObjectResult(ServiceResult.Error(problemDetails, HttpStatusCode.BadRequest))
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }
}