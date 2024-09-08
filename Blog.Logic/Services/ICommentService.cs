using Blog.Logic.Models;

namespace Blog.Logic.Services
{
    public interface ICommentService
    {
        public Task CreateComment(CommentModel comment);
        public Task<CommentModel> GetComment(int id);
        public List<CommentModel> GetComments();
        public Task UpdateComment(CommentModel comment);
        public Task DeleteComment(CommentModel comment);
    }
}
