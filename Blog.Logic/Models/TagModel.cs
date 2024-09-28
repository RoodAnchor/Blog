using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class TagModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(2, ErrorMessage = "Длина имени должна быть минимум 2 символа")]
    public string? Name { get; set; }
    public List<PostModel> Posts { get; set; } = [];
}
