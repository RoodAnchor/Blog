using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
[Authorize(Roles = "Администратор")]
public class RolesController : Controller
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Index(int id)
    {
        var role = await _roleService.GetRole(id);

        return View(role);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> All()
    {
        var roles = _roleService.GetRoles();

        return View(roles);
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult Add()
    {
        return View(new RoleModel());
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Add(RoleModel role)
    {
        if (!ModelState.IsValid)
            return View(role);

        await _roleService.CreateRole(role);

        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var role = await _roleService.GetRole(id);

        return View(role);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Edit(RoleModel role)
    {
        if(!ModelState.IsValid)
            return View(role);

        await _roleService.UpdateRole(role);

        return RedirectToAction("Index", new { Id = role.Id });
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Delete(RoleModel role)
    {
        var _role = await _roleService.GetRole(role.Id);

        await _roleService.DeleteRole(role);

        return RedirectToAction("All");
    }
}