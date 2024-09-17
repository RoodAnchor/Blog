namespace Blog.Logic.Models;

public class PostModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel? User { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public List<TagModel> Tags { get; set; } = [];
    public List<CommentModel> Comments { get; set; } = [];
    public int Views { get; set; }
}