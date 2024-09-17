using Blog.Data.DB;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class TagRepository : BaseRepository<TagEntity>
{
    public TagRepository(BlogDbContext db) : base(db) { }

    public new async Task<List<TagEntity>> GetAll() 
    {
        return await Set
            .Include(x => x.Posts)
            .ToListAsync();
    }

    public new async Task<TagEntity?> Get(int id)
    {
        return await Set
            .Include(x => x.Posts)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}