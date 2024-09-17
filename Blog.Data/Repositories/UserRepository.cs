using Blog.Data.DB;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class UserRepository : BaseRepository<UserEntity>
{
    public UserRepository(BlogDbContext db) : base(db) { }

    public new Task<List<UserEntity>> GetAll()
    {
        return Set
            .Include(x => x.Roles)
            .Include(x => x.Posts)
            .ToListAsync();
    }

    public new async Task<UserEntity?> Get(int id)
    {
        return await Set
            .Include(x => x.Roles)
            .Include(x => x.Posts)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserEntity?> Get(string email)
    {
        return await Set
            .Include(x => x.Roles)
            .Include(x => x.Posts)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}