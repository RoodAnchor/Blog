using Blog.Data.DB;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class CommentRepository : BaseRepository<CommentEntity>
    {
        public CommentRepository(BlogDbContext blogDbContext) : base(blogDbContext) { }
    }
}
