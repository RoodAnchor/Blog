using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class SignInViewModel
{
    [Required(ErrorMessage = "Заполните это поле")]
    [EmailAddress(ErrorMessage = "Недопустимый формат Email'а")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(5, ErrorMessage = "Длина пароля должна быть минимум 5 символа")]
    public string Password { get; set; }
}