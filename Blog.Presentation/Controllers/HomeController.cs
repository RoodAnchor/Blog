﻿using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}