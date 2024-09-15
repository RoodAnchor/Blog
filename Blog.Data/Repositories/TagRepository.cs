using Blog.Data.DB;
using Blog.Data.Entities;

namespace Blog.Data.Repositories;

public class TagRepository : BaseRepository<TagEntity>
{
    public TagRepository(BlogDbContext db) : base(db) { }
}