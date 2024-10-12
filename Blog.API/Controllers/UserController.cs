using AutoMapper;
using Blog.API.Contracts.Models.User;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;
    private IRoleService _roleService;
    private IMapper _mapper;

    public UserController(
        IUserService userService,
        IRoleService roleService,
        IMapper mapper)
    {
        _userService = userService;
        _roleService = roleService;
        _mapper = mapper;
    }

    #region Create
    [HttpPost]
    [Route("[action]")]
    public async Task Create([FromBody] CreateUserRequest newUser)
    {
        var user = _mapper.Map<UserModel>(newUser);

        await _userService.RegisterUser(user);
    }
    #endregion Create

    #region Read
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<GetUserResponse?> GetById(int id)
    {
        var user = await _userService.GetUser(id);

        return _mapper.Map<GetUserResponse?>(user);
    }        

    [HttpGet]
    [Route("[action]/{email}")]
    public async Task<GetUserResponse?> GetByEmail(string email)
    {
        var user = await _userService.GetUser(email);

        return _mapper.Map<GetUserResponse?>(user);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IEnumerable<GetUserResponse>> GetAll()
    {
        var users = await _userService.GetAllUsers();

        return _mapper.Map<IEnumerable<GetUserResponse>>(users);
    }
    #endregion Read

    #region Update
    [HttpPut]
    [Route("[action]")]
    public async Task Update([FromBody] UpdateUserRequest updatedUser) 
    {
        var user = _mapper.Map<UserModel>(updatedUser);
        var roles = _roleService.GetRoles().Where(x => updatedUser.RoleIds.Contains(x.Id));

        user.Roles = roles.ToList();

        await _userService.UpdateUser(user);
    }
    #endregion Update

    #region Delete
    [HttpDelete]
    [Route("[action]")]
    public async Task Delete([FromBody] DeleteUserRequest userToDelete) 
    {
        var user = _mapper.Map<UserModel>(userToDelete);

        await _userService.DeleteUser(user);
    }
    #endregion Delete
}
