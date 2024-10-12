using Blog.API.Contracts.Models.Role;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;
public class RoleMapping : MappingProfile
{
    public override void BuildMappings()
    {
        CreateMap<RoleEntity, RoleModel>().ReverseMap();
        CreateMap<RoleModel, CreateRoleRequest>().ReverseMap();
        CreateMap<RoleModel, GetRoleResponse>().ReverseMap();
        CreateMap<RoleModel, UpdateRoleRequest>().ReverseMap();
        CreateMap<RoleModel, DeleteRoleRequest>().ReverseMap();
    }
}
