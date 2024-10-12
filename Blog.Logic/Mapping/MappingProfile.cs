using AutoMapper;

namespace Blog.Logic.Mapping;

public abstract class MappingProfile : Profile
{
    public MappingProfile() =>
        BuildMappings();

    public abstract void BuildMappings();
}