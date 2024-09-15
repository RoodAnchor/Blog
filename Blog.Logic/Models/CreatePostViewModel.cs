namespace Blog.Logic.Models;

public class CreatePostViewModel
{
    public List<TagModel> Tags { get; set; }
    public PostModel Post { get; set; }
    public string SelectedTagIds { get; set; }

    public CreatePostViewModel()
    {
        Tags = new List<TagModel>();
    }
}