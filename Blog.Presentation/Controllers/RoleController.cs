using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Models;
using Blog.Logic.Services;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class RoleController : Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult Create()
    {
        return View(new RoleModel());
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(RoleModel role)
    {
        await _roleService.CreateRole(role);

        return View(role);
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
        await _roleService.UpdateRole(role);

        return View(role.Id);
    }
}