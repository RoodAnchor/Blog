using Blog.Logic.Models;

namespace Blog.Logic.Services;
public interface ILogService
{
    Task<List<LogModel>> GetLogs(int page);
    int GetLogsCount();
}
