namespace Blog.Data.Entities;

public class TagEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<PostEntity> Posts { get; set; }
}