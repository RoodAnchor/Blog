namespace Blog.API.Contracts.Models.Post;
public class CreatePostRequest
{
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public int[] TagIds { get; set; } = [];
}
