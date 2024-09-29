using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
[Authorize(Roles = "Администратор")]
public class RolesController : Controller
{
    private readonly ILogger<RolesController> _logger;
    private readonly IRoleService _roleService;

    public RolesController(
        ILogger<RolesController> logger,
        IRoleService roleService)
    {
        _logger = logger;
        _roleService = roleService;
    }

    public async Task<IActionResult> Index()
    {
        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Index(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var role = await _roleService.GetRole(id);

        return View(role);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> All()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var roles = _roleService.GetRoles();

        return View(roles);
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult Add()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        return View(new RoleModel());
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Add(RoleModel role)
    {
        _logger.LogInformation($"Log Entry: Добавление роли");

        if (!ModelState.IsValid)
            return View(role);

        await _roleService.CreateRole(role);

        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var role = await _roleService.GetRole(id);

        return View(role);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Edit(RoleModel role)
    {
        _logger.LogInformation($"Log Entry: Редактирование роли. ID: {role.Id}");

        if (!ModelState.IsValid)
            return View(role);

        await _roleService.UpdateRole(role);

        return RedirectToAction("Index", new { Id = role.Id });
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Delete(RoleModel role)
    {
        _logger.LogInformation($"Log Entry: Удаление роли. ID: {role.Id}");

        var _role = await _roleService.GetRole(role.Id);

        await _roleService.DeleteRole(role);

        return RedirectToAction("All");
    }
}