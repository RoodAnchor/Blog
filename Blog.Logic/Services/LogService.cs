using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Models;

namespace Blog.Logic.Services;
public class LogService : ILogService
{
    private readonly IRepository<LogEntity> _logRepository;
    private readonly IUserService? _userService;
    private readonly IMapper _mapper;

    public LogService(
        IUnitOfWork unitOfWork,
        IUserService userService,
        IMapper mapper)
    {
        _logRepository = unitOfWork.GetRepository<LogEntity>(false);
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<List<LogModel>> GetLogs(int page)
    {
        var take = 50;
        var skip = page < 2 ? 0 : (page-1) * take;

        var entities = _logRepository!
            .GetAll()
            .OrderByDescending(x => x.Date)
            .Skip(skip)
            .Take(take);
        var logs = _mapper.Map<List<LogModel>>(entities);

        logs.ForEach(async x => x.User = await _userService!.GetUser(x.UserEmail));

        return logs;
    }

    public int GetLogsCount() =>
        _logRepository!.GetAll().Count();
}
