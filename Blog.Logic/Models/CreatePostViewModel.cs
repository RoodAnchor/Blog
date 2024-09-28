using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class CreatePostViewModel
{
    public List<TagModel> Tags { get; set; }
    public PostModel Post { get; set; }

    [Required(ErrorMessage = "Выберите минимум один тэг")]
    public string SelectedTagIds { get; set; }

    public CreatePostViewModel()
    {
        Tags = new List<TagModel>();
    }
}