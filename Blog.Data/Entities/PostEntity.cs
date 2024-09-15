namespace Blog.Data.Entities;

public class PostEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
    public List<TagEntity> Tags { get; set; }
}