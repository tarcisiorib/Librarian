using System;
using System.Net;
using Librarian.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace Librarian.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ExceptionHandlingMiddleware(RequestDelegate next, ProblemDetailsFactory problemDetailsFactory)
    {
        _next = next;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var problem = new ProblemDetails();
        problem.Instance = httpContext.Request.Path;
        problem.Detail = exception?.Message;

        switch (exception)
        {
                        case BadRequestException badRequestException:
                foreach (var error in badRequestException.Errors)
                    problem.Extensions.Add(error.Key, error.Value);
                problem.Status = (int)HttpStatusCode.InternalServerError;
                break;

            case NotFoundException notFoundException:
                problem.Status = (int)HttpStatusCode.NotFound;
                break;
                
            default:
                problem.Status = (int)HttpStatusCode.InternalServerError;
                break;
        }

        ProblemDetails problemDetails;
        if (_problemDetailsFactory != null)
        {
            problemDetails = _problemDetailsFactory.CreateProblemDetails(httpContext, statusCode: problem.Status);
            problem.Title = problemDetails.Title;
            problem.Type = problemDetails.Type;
        }

        var result = new ObjectResult(problem);
        var response = JsonConvert.SerializeObject(result.Value);
        httpContext.Response.ContentType = "application/problem+json";
        await httpContext.Response.WriteAsync(response);
    }
}
