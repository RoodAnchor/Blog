using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;    
    private readonly IRoleService _roleService;

    public UserController(
        IUserService userService,
        IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsers();

        return View(users);
    }

    /// <summary>
    /// Регистрация пользоваталя
    /// </summary>
    /// <param name="userModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task SignUp(UserModel user)
    {
        await _userService.RegisterUser(user);
    }

    /// <summary>
    /// Получаем пользователя по ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<UserModel> GetUser(int id)
    {
        return await _userService.GetUser(id);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
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
    public async Task<IActionResult> Edit(EditUserViewModel vm)
    {
        await _userService.UpdateUser(vm.User);

        return View(vm.User.Id);
    }

    /// <summary>
    /// Удаляем пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Delete(UserModel user)
    {
        await _userService.DeleteUser(user);
    }
}