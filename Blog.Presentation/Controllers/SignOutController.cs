using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

public class SignOutController : Controller
{
    public async Task<IActionResult> Index()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}