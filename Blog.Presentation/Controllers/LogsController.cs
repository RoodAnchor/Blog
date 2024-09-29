using Blog.Logic.Models;
using Blog.Logic.Services;
using Blog.Presentation.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[ExceptionHandler]
[Authorize(Roles = "Администратор")]
public class LogsController : Controller
{
    private readonly ILogService _logService;

    public LogsController(ILogService logService) =>
        _logService = logService;

    public async Task<IActionResult> Index([FromQuery]int page = 1)
    {
        var vm = new LogsViewModel()
        {
            Logs = await _logService.GetLogs(page),
            PageCount = _logService.GetLogsCount() / 50,
            CurrentPage = page
            
        };

        return View(vm);
    }
}
