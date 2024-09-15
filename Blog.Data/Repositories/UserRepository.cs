using Blog.Data.DB;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class UserRepository : BaseRepository<UserEntity>
{
    public UserRepository(BlogDbContext db) : base(db) { }

    public new async Task<List<UserEntity>> GetAll()
    {
        return await Set
            .Include(x => x.Roles)
            .ToListAsync();
    }

    public new async Task<UserEntity?> Get(int id)
    {
        return await Set
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserEntity?> Get(string email)
    {
        return await Set
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}