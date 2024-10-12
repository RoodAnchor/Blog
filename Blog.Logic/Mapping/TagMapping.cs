using Blog.API.Contracts.Models.Tag;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;
public class TagMapping : MappingProfile
{
    public override void BuildMappings()
    {
        CreateMap<TagEntity, TagModel>().ReverseMap();
        CreateMap<TagModel, CreateTagRequest>().ReverseMap();
        CreateMap<TagModel, GetTagResponse>().ReverseMap();
        CreateMap<TagModel, UpdateTagRequest>().ReverseMap();
        CreateMap<TagModel, DeleteTagRequest>().ReverseMap();
    }
}
