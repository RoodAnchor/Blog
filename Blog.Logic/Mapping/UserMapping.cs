using Blog.API.Contracts.Models.User;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;
public class UserMapping : MappingProfile
{
    public override void BuildMappings()
    {
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<UserModel, CreateUserRequest>().ReverseMap();
        CreateMap<UserModel, GetUserResponse>().ReverseMap();
        CreateMap<UserModel, UpdateUserRequest>().ReverseMap();
        CreateMap<UserModel, DeleteUserRequest>().ReverseMap();
    }
}
