using Blog.API.Contracts.Models.User;
using Blog.API.Contracts.Models.Tag;
using Blog.API.Contracts.Models.Comment;

namespace Blog.API.Contracts.Models.Post;
public class GetPostResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public GetUserResponse? User { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
    public List<GetTagResponse> Tags { get; set; } = [];
    public List<GetCommentResponse> Comments { get; set; } = [];
    public int Views { get; set; }
}
