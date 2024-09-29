using Blog.Data.DB;
using Blog.Data.Entities;

namespace Blog.Data.Repositories;
public class LogRepository : BaseRepository<LogEntity>
{
    public LogRepository(BlogDbContext db) : base(db) { }
}
