using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FluentValidation;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace KayraExport.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            object response;

            switch (exception)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    response = new
                    {
                        StatusCode = (int)statusCode,
                        Message = exception.Message
                    };
                    break;

                case ValidationException validationEx:
                    statusCode = HttpStatusCode.BadRequest;
                    response = new
                    {
                        StatusCode = (int)statusCode,
                        Message = "Validation failed",
                        Errors = validationEx.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                    };
                    break;

                default:
                    response = new
                    {
                        StatusCode = (int)statusCode,
                        Message = exception.Message
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
