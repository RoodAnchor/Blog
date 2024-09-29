namespace Blog.Logic.Models;

public class LogsViewModel
{
    public List<LogModel> Logs { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
}
