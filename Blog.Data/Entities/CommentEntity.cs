namespace Blog.Data.Entities;

public class CommentEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public int PostId { get; set; }
    public PostEntity? Post { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}