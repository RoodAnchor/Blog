using Blog.Logic.Models;

namespace Blog.Logic.Services
{
    public interface IPostService
    {
        public Task CreatePost(PostModel post);
        public List<PostModel> GetPosts();
        public List<PostModel> GetPosts(int authorId);
        public Task UpdatePost(PostModel post);
        public Task DeletePost(PostModel post);
    }
}
