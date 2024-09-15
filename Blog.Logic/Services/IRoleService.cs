using Blog.Logic.Models;

namespace Blog.Logic.Services;

public interface IRoleService
{
    public Task CreateRole(RoleModel role);
    public Task<RoleModel> GetRole(int id);
    public List<RoleModel> GetRoles();
    public Task UpdateRole(RoleModel role);
    public Task DeleteRole(RoleModel role);
}