using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class UserModel
{
    private string _picture;

    public int Id { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    public string? SecondName { get; set; }
    public string? PatronymicName { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [EmailAddress(ErrorMessage = "Недопустимый формат Email'а")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(5, ErrorMessage = "Длина пароля должна быть минимум 5 символа")]
    public string? Password { get; set; }

    [ValidateNever]
    public string About { get; set; }
    public string Picture 
    {
        get => string.IsNullOrEmpty(_picture) ? "https://thispersondoesnotexist.com/" : _picture;
        set => _picture = value; 
    }

    [Required(ErrorMessage = "Заполните это поле")]
    public DateTime? BirthDate { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    public List<RoleModel> Roles { get; set; } = [];
    public List<CommentModel> Comments { get; set; } = [];
    public List<PostModel> Posts { get; set; } = [];
}
