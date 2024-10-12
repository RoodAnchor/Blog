namespace Blog.API.Contracts.Models.Comment;
public class CreateCommentRequest
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string? Content { get; set; }
}
