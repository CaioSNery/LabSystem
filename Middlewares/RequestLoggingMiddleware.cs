using System.Diagnostics;

namespace SystemLab.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();

        try
        {
            await _next(context);
        }
        finally
        {
            watch.Stop();

            Console.WriteLine(
                $"{DateTime.Now:HH:mm:ss} {context.Request.Method} {context.Request.Path} - {context.Response.StatusCode} - {watch.ElapsedMilliseconds}ms");
        }
    }
}