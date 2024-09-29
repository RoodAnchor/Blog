namespace Blog.Data.Entities;
public class LogEntity
{
    public int Id { get; set; }
    public string Level { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string UserEmail { get; set; }
    public string? ClientIP { get; set; }
    public string? Message { get; set; }
}
