using Blog.Data.DB;
using Blog.Data.Entities;

namespace Blog.Data.Repositories;

public class RoleRepository : BaseRepository<RoleEntity>
{
    public RoleRepository(BlogDbContext db) : base(db) { }
}