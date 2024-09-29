using Blog.Presentation.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[ExceptionHandler]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) =>
        _logger = logger;

    public IActionResult Index()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        return View();
    }
}