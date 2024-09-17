using Blog.Logic.Models;

namespace Blog.Logic.Services;

public interface IPostService
{
    public Task CreatePost(PostModel post);
    public Task<PostModel> GetPost(int id);
    public Task<List<PostModel>> GetPosts();
    public Task<List<PostModel>> GetPostsByAuthor(int authorId);
    public Task<List<PostModel>> GetPostsByTag(int tagId);
    public Task UpdatePost(PostModel post);
    public Task DeletePost(PostModel post);
}
