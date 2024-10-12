using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;
public class LogMapping : MappingProfile
{
    public override void BuildMappings()
    {
        CreateMap<LogEntity, LogModel>().ReverseMap();
    }
}
