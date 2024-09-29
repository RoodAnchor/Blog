using Microsoft.AspNetCore.Diagnostics;

namespace Blog.Presentation.Utils;

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger) => 
        _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        _logger.LogError($"Log Entry: {exception.Message}");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.Redirect("/Errors");

        return true;
    }
}
