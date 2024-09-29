using Blog.Logic.Models;
using Blog.Logic.Services;
using Blog.Presentation.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[ExceptionHandler]
[Route("[controller]")]
public class SignUpController : Controller
{
    private readonly ILogger<SignUpController> _logger;
    private readonly IUserService _userService;

    public SignUpController(
        ILogger<SignUpController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserModel newUser)
    {
        if(!ModelState.IsValid)
            return View(newUser);

        var user = await _userService.RegisterUser(newUser);

        _logger.LogInformation($"Log Entry: Успешная регистрация. Email: {newUser.Email}");

        return RedirectToAction("All", "Posts");
    }
}