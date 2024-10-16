﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Logic.Models;

public class RoleModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(2, ErrorMessage = "Длина имени должна быть минимум 2 символа")]
    [MaxLength(50, ErrorMessage = "Длина имени не должна привышать 50 символов")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Заполните это поле")]
    [MinLength(2, ErrorMessage = "Длина описания должна быть минимум 2 символа")]
    [MaxLength(100, ErrorMessage = "Длина описания не должна привышать 100 символов")]
    public string Description { get; set; }
}
