using Blog.Data.DB;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class PostRepository : BaseRepository<PostEntity>
    {
        public PostRepository(BlogDbContext db) : base(db) { }
    }
}
