using System.Net;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CourseMarket.Application.Wrappers;

public class ServiceResult
{
    public HttpStatusCode Status { get; set; }

    public ProblemDetails? Fail { get; set; }

    public static ServiceResult SuccessAsNoContent()
    {
        return new ServiceResult
        {
            Status = HttpStatusCode.NoContent
        };
    }

    public static ServiceResult ErrorAsNotFound()
    {
        return new ServiceResult
        {
            Status = HttpStatusCode.NotFound,
            Fail = new ProblemDetails
            {
                Title = "Not Found",
                Detail = "The requested resource was not found"
            }
        };
    }


    public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode status)
    {
        return new ServiceResult
        {
            Status = status,
            Fail = problemDetails
        };
    }

    public static ServiceResult Error(string title, string description, HttpStatusCode status)
    {
        return new ServiceResult
        {
            Status = status,
            Fail = new ProblemDetails()
            {
                Title = title,
                Detail = description,
                Status = status.GetHashCode()
            }
        };
    }

    public static ServiceResult Error(string title, HttpStatusCode status)
    {
        return new ServiceResult
        {
            Status = status,
            Fail = new ProblemDetails()
            {
                Title = title,
                Status = status.GetHashCode()
            }
        };
    }
}

public class ServiceResult<T> : ServiceResult
{
    public T? Data { get; set; }

    public string? UrlAsCreated { get; set; }

    public static ServiceResult<T> SuccessAsOk(T data)
    {
        return new ServiceResult<T>
        {
            Status = HttpStatusCode.OK,
            Data = data
        };
    }

    public static ServiceResult<T> SuccessAsCreated(T data, string url)
    {
        return new ServiceResult<T>
        {
            Status = HttpStatusCode.Created,
            Data = data,
            UrlAsCreated = url
        };
    }

    public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode status)
    {
        return new ServiceResult<T>
        {
            Status = status,
            Fail = problemDetails
        };
    }

    public new static ServiceResult<T> Error(string title, string description, HttpStatusCode status)
    {
        return new ServiceResult<T>
        {
            Status = status,
            Fail = new ProblemDetails()
            {
                Title = title,
                Detail = description,
                Status = status.GetHashCode()
            }
        };
    }
}