using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Presentation.Utils;

public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
{
    public void OnException(ExceptionContext context) 
    {
        var logger = context.HttpContext.RequestServices.GetService(typeof(ILogger)) as ILogger;

        if (logger != null)
            logger.LogError($"Log Entry: {context.Exception.Message}");

        context.Result = new RedirectToActionResult("Index", "Errors", null);
    }
}
