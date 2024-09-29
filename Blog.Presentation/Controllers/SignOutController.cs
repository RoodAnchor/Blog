using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

public class SignOutController : Controller
{
    private readonly ILogger<SignOutController> _logger;

    public SignOutController(ILogger<SignOutController> logger) =>
        _logger = logger;

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation($"Log Entry: Выход");

        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}