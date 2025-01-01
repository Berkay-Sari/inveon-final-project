using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Extensions;

public static class ConfigureExceptionHandlerExtension
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static void ConfigureExceptionHandler<T>(this WebApplication app, ILogger<T> logger)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    var error = contextFeature.Error;

                    var username = context.User?.Identity?.Name ?? "Anonymous";

                    logger.LogError(error,
                        "Unhandled exception occurred: {Message}, TraceId: {TraceId}, Username: {Username}",
                        error.Message,
                        context.TraceIdentifier,
                        username
                    );

                    var (statusCode, title, detail) = error switch
                    {
                        ArgumentNullException => ((int)HttpStatusCode.BadRequest, "Bad Request", "One or more arguments were null."),
                        _ => ((int)HttpStatusCode.InternalServerError, "Internal Server Error", "An unexpected error occurred.")
                    };

                    var errorResponse = new ProblemDetails
                    {
                        Status = statusCode,
                        Title = title,
                        Detail = detail,
                        Instance = context.TraceIdentifier
                    };

                    context.Response.StatusCode = statusCode;

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, JsonSerializerOptions));
                }
            });
        });
    }
}
