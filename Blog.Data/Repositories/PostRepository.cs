using Blog.Data.DB;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class PostRepository : BaseRepository<PostEntity>
{
    public PostRepository(BlogDbContext db) : base(db) { }

    public new async Task<List<PostEntity>> GetAll()
    {
        return await Set
            .Include(x => x.Tags)
            .ToListAsync();
    }

    public new async Task<PostEntity?> Get(int id)
    {
        return await Set
            .Include(x => x.Tags)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}