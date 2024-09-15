using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Models;
using Blog.Logic.Services;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class SignInController : Controller
{
    private readonly IUserService _userService;

    public SignInController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(SignInViewModel creds)
    {
        var user = await _userService.AuthenticateUser(creds);

        if (user == null)
            throw new AuthenticationException("Неверные имя пользователя или пароль");

        var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
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

        return View();
    }
}