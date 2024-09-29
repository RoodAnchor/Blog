using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;    
    private readonly IRoleService _roleService;

    public UsersController(
        ILogger<UsersController> logger,
        IUserService userService,
        IRoleService roleService)
    {
        _logger = logger;
        _userService = userService;
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

        var user = await _userService.GetUser(id);

        return View(user);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> All()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var users = await _userService.GetAllUsers();

        return View(users);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    [Authorize(Policy = "OwnerOnly")]
    public async Task<IActionResult> Edit(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var vm = new EditUserViewModel();

        vm.Roles = _roleService.GetRoles();
        vm.User = await _userService.GetUser(id);

        return View(vm);
    }

    /// <summary>
    /// Обвновляем пользователя
    /// </summary>
    /// <param name="vm"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Edit(EditUserViewModel vm)
    {
        _logger.LogInformation($"Log Entry: Редактирование пользователя. ID: {vm.User.Id}");

        vm.User.Roles = await GetRoles(vm.SelectedRoleIds);

        await _userService.UpdateUser(vm.User);

        return RedirectToAction("Index", new { id = vm.User.Id });
    }

    /// <summary>
    /// Удаляем пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Delete(UserModel user)
    {
        _logger.LogInformation($"Log Entry: Удаление пользователя. ID: {user.Id}");

        await _userService.DeleteUser(user.Id);

        return RedirectToAction("All");
    }

    private async Task<List<RoleModel>> GetRoles(string selectdRoles)
    {
        var roles = new List<RoleModel>();
        var roleIds = selectdRoles.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var roleId in roleIds)
        {
            var role = await _roleService.GetRole(int.Parse(roleId));

            if (role != null) roles.Add(role);
        }

        return roles;
    }
}