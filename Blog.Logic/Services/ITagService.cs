using Blog.Logic.Models;

namespace Blog.Logic.Services;

public interface ITagService
{
    public Task CreateTag(TagModel tag);
    public Task<TagModel> GetTag(int id);
    public Task<List<TagModel>> GetTags();
    public Task UpdateTag(TagModel tag);
    public Task DeleteTag(int id);
}