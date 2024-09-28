using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class CommentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel? User { get; set; }
    public int PostId { get; set; }
    public PostModel? Post { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(2, ErrorMessage = "Длина сообщения должна быть минимум 2 символа")]
    [MaxLength(2000, ErrorMessage = "Длина сообщения не должна привышать 2000 символов")]
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}