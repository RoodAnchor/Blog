﻿using AutoMapper;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<RoleEntity, RoleModel>().ReverseMap();
        CreateMap<TagEntity, TagModel>().ReverseMap();
        CreateMap<PostEntity, PostModel>().ReverseMap();
        CreateMap<CommentEntity, CommentModel>().ReverseMap();
        CreateMap<LogEntity, LogModel>().ReverseMap();
    }
}