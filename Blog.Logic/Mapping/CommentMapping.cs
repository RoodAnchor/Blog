using Blog.API.Contracts.Models.Comment;
using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Mapping;
public class CommentMapping : MappingProfile
{
    public override void BuildMappings()
    {
        CreateMap<CommentEntity, CommentModel>().ReverseMap();
        CreateMap<CommentModel, CreateCommentRequest>().ReverseMap();
        CreateMap<CommentModel, GetCommentResponse>().ReverseMap();
        CreateMap<CommentModel, UpdateCommentRequest>().ReverseMap();
        CreateMap<CommentModel, DeleteCommentRequest>().ReverseMap();
    }
}
