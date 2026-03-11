

using System.Net;
using System.Runtime.ExceptionServices;
using System.Text.Json;

namespace LabSystem.Middlewares
{
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                message = "Erro interno do servidor",
                detail = ex.Message,
                context.Response.StatusCode,
                DateTime.UtcNow,
                context.Request.Path
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }



    }
}