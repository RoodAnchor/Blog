using Blog.API.Contracts.Models.User;

namespace Blog.API.Contracts.Models.Comment;
public class GetCommentResponse
{
    public int Id { get; set; }
    public GetUserResponse? User { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
}