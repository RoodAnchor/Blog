using Blog.API.Contracts.Models.Post;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;
public class PostMapping : MappingProfile
{
    public override void BuildMappings()
    {
        CreateMap<PostEntity, PostModel>().ReverseMap();
        CreateMap<PostModel, CreatePostRequest>().ReverseMap();
        CreateMap<PostModel, GetPostResponse>().ReverseMap();
        CreateMap<PostModel, UpdatePostRequest>().ReverseMap();
        CreateMap<PostModel, DeletePostRequest>().ReverseMap();
    }
}
