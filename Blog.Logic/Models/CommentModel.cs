﻿namespace Blog.Logic.Models;

public class CommentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel? User { get; set; }
    public int PostId { get; set; }
    public PostModel? Post { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}