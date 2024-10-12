using AutoMapper;
using Blog.API.Contracts.Models.Comment;
using Blog.API.Contracts.Models.Post;
using Blog.API.Contracts.Models.Role;
using Blog.API.Contracts.Models.Tag;
using Blog.API.Contracts.Models.User;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<UserModel, CreateUserRequest>().ReverseMap();
        CreateMap<UserModel, GetUserResponse>().ReverseMap();
        CreateMap<UserModel, UpdateUserRequest>().ReverseMap();
        CreateMap<UserModel, DeleteUserRequest>().ReverseMap();

        CreateMap<RoleEntity, RoleModel>().ReverseMap();
        CreateMap<RoleModel, CreateRoleRequest>().ReverseMap();
        CreateMap<RoleModel, GetRoleResponse>().ReverseMap();
        CreateMap<RoleModel, UpdateRoleRequest>().ReverseMap();
        CreateMap<RoleModel, DeleteRoleRequest>().ReverseMap();

        CreateMap<TagEntity, TagModel>().ReverseMap();
        CreateMap<TagModel, CreateTagRequest>().ReverseMap();
        CreateMap<TagModel, GetTagResponse>().ReverseMap();
        CreateMap<TagModel, UpdateTagRequest>().ReverseMap();
        CreateMap<TagModel, DeleteTagRequest>().ReverseMap();

        CreateMap<PostEntity, PostModel>().ReverseMap();
        CreateMap<PostModel, CreatePostRequest>().ReverseMap();
        CreateMap<PostModel, GetPostResponse>().ReverseMap();
        CreateMap<PostModel, UpdatePostRequest>().ReverseMap();
        CreateMap<PostModel, DeletePostRequest>().ReverseMap();

        CreateMap<CommentEntity, CommentModel>().ReverseMap();
        CreateMap<CommentModel, CreateCommentRequest>().ReverseMap();
        CreateMap<CommentModel, GetCommentResponse>().ReverseMap();
        CreateMap<CommentModel, UpdateCommentRequest>().ReverseMap();
        CreateMap<CommentModel, DeleteCommentRequest>().ReverseMap();

        CreateMap<LogEntity, LogModel>().ReverseMap();
    }
}