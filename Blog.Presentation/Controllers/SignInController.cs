using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Models;
using Blog.Logic.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class SignInController : Controller
{
    private readonly ILogger<SignInController> _logger;
    private readonly IUserService _userService;

    public SignInController(
        ILogger<SignInController> logger,
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(SignInViewModel creds)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.AuthenticateUser(creds);

            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email!),
                    new Claim("Id", user.Id.ToString())
                };

                foreach (var role in user.Roles)
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    "AppCookie",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                _logger.LogInformation($"Log Entry: Успешная авториция");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                _logger.LogInformation($"Log Entry: Безуспешная авториция");

                ModelState.AddModelError("", "Неправильные логин и (или) пароль");

                return View(creds);
            }
        }

        _logger.LogInformation($"Log Entry: Безуспешная авториция");

        return View(creds);
    }
}