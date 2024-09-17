namespace Blog.Logic.Models;

public class TagModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<PostModel> Posts { get; set; } = [];
}
