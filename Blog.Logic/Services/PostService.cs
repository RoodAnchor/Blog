using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Extensions;
using Blog.Logic.Models;
using Blog.Logic.Exceptions;

namespace Blog.Logic.Services;

public class PostService : IPostService
{
    private readonly IRepository<PostEntity> _repo;
    private readonly IMapper _mapper;

    public PostService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repo = unitOfWork.GetRepository<PostEntity>(false);
        _mapper = mapper;
    }

    public async Task CreatePost(PostModel post)
    {
        var entity = _mapper.Map<PostEntity>(post);

        await _repo.Create(entity);
    }

    public async Task<PostModel> GetPost(int id)
    {
        var entity = await _repo.Get(id);
        var post = _mapper.Map<PostModel>(entity);

        return post;
    }

    public List<PostModel> GetPosts()
    {
        var entities = _repo.GetAll();
        var posts = _mapper.Map<List<PostModel>>(entities);

        return posts;
    }

    public List<PostModel> GetPosts(int authorId)
    {
        return GetPosts().Where(x => x.UserId == authorId).ToList();
    }

    public async Task UpdatePost(PostModel post)
    {
        var entity = await _repo.Get(post.Id);

        if (entity == null) throw new PostNotFoundException();

        entity.MergeChanges(post);

        await _repo.Update(entity);
    }

    public async Task DeletePost(PostModel post)
    {
        var entity = await _repo.Get(post.Id);

        if (entity == null) throw new PostNotFoundException();

        await _repo.Delete(entity);
    }
}