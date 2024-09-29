using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Route("[controller]")]
    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"Message: {exceptionFeature.Error.Message}, Path: {exceptionFeature.Path}");

            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult AccessDenied()
        {
            _logger.LogError($"Message: Access denied, Path: {HttpContext.Request.Query["ReturnUrl"]}");

            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ResourceNotFound()
        {
            _logger.LogError($"Message: Resource not found, Path: {HttpContext.Request.Query["RequestUrl"]}");

            return View();
        }
    }
}
