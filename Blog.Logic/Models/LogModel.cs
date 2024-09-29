using Blog.Data.Entities;

namespace Blog.Logic.Models;
public class LogModel
{
    public int Id { get; set; }
    public string Level { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string UserEmail { get; set; }
    public UserModel? User { get; set; }
    public string? ClientIP { get; set; }
    public string? Message { get; set; }
}
