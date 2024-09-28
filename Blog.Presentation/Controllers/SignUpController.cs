using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class SignUpController : Controller
{
    private readonly IUserService _userService;

    public SignUpController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserModel newUser)
    {
        if(!ModelState.IsValid)
            return View(newUser);

        var user = await _userService.RegisterUser(newUser);

        return RedirectToAction("All", "Posts");
    }
}