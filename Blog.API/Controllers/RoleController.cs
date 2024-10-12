using AutoMapper;
using Blog.API.Contracts.Models.Role;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private IRoleService _roleService;
    private IMapper _mapper;

    public RoleController(
        IRoleService roleService, 
        IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    #region Create
    [HttpPost]
    [Route("[action]")]
    public async Task Create([FromBody] CreateRoleRequest newRole)
    {
        var role = _mapper.Map<RoleModel>(newRole);

        await _roleService.CreateRole(role);
    }
    #endregion Create

    #region Read
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<GetRoleResponse> GetById(int id)
    {
        var role = await _roleService.GetRole(id);

        return _mapper.Map<GetRoleResponse>(role);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IEnumerable<GetRoleResponse>> GetAll()
    {
        var roles = _roleService.GetRoles();

        return _mapper.Map<IEnumerable<GetRoleResponse>>(roles);
    }
    #endregion Read

    #region Update
    [HttpPut]
    [Route("[action]")]
    public async Task Update([FromBody] UpdateRoleRequest updatedRole)
    {
        var role = _mapper.Map<RoleModel>(updatedRole);

        await _roleService.UpdateRole(role);
    }
        
    #endregion Update

    #region Delete
    [HttpDelete]
    [Route("[action]")]
    public async Task Delete([FromBody] DeleteRoleRequest roleToDelete)
    {
        var role = _mapper.Map<RoleModel>(roleToDelete);

        await _roleService.DeleteRole(role);
    }
    #endregion Delete
}
