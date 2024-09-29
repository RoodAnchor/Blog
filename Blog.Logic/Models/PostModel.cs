using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class PostModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel? User { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(10, ErrorMessage = "Длина заголовка должна быть минимум 2 символа")]
    [MaxLength(50, ErrorMessage = "Длина заголовка не должна привышать 2000 символов")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(10, ErrorMessage = "Длина описания должна быть минимум 2 символа")]
    [MaxLength(100, ErrorMessage = "Длина описания не должна привышать 2000 символов")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(10, ErrorMessage = "Длина контента должна быть минимум 10 символа")]
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public List<TagModel> Tags { get; set; } = [];
    public List<CommentModel> Comments { get; set; } = [];
    public int Views { get; set; }
}