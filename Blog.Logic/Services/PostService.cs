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
    private readonly PostRepository? _postRepo;
    private readonly TagRepository? _tagRepo;
    private readonly UserRepository? _userRepo;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public PostService(
        IUnitOfWork unitOfWork,
        ITagService tagService,
        IMapper mapper)
    {
        _postRepo = unitOfWork.GetRepository<PostEntity>() as PostRepository;
        _tagRepo = unitOfWork.GetRepository<TagEntity>() as TagRepository;
        _userRepo = unitOfWork.GetRepository<UserEntity>() as UserRepository;
        _tagService = tagService;
        _mapper = mapper;
    }

    public async Task CreatePost(PostModel post)
    {
        var entity = _mapper.Map<PostEntity>(post);
        var userEntity = await _userRepo!.Get(post.User!.Id);

        entity.User = userEntity;
        entity.Tags.Clear();

        foreach(var tag in post.Tags)
        {
            var tagEntity = await _tagRepo!.Get(tag.Id);

            if (tagEntity != null)
                entity.Tags.Add(tagEntity);
        }

        await _postRepo!.Create(entity);
    }

    public async Task<PostModel> GetPost(int id)
    {
        var entity = await _postRepo!.Get(id);

        if (entity == null) throw new PostNotFoundException();

        var post = _mapper.Map<PostModel>(entity);

        return post;
    }

    public async Task<List<PostModel>> GetPosts()
    {
        var entities = await _postRepo!.GetAll();
        var posts = _mapper.Map<List<PostModel>>(entities);

        return posts;
    }

    public async Task<List<PostModel>> GetPostsByAuthor(int authorId)
    {
        var posts = await GetPosts();

        return posts.Where(x => x.UserId == authorId).ToList();
    }

    public async Task<List<PostModel>> GetPostsByTag(int tagId)
    {
        var tag = await _tagService.GetTag(tagId);

        return tag.Posts;
    }

    public async Task UpdatePost(PostModel post)
    {
        var entity = await _postRepo!.Get(post.Id);

        if (entity == null) throw new PostNotFoundException();

        entity.MergeChanges(post);

        entity.Tags.Clear();

        foreach (var tag in post.Tags)
        {
            var tagEntity = await _tagRepo!.Get(tag.Id);

            if (tagEntity != null)
                entity.Tags.Add(tagEntity);
        }

        await _postRepo.Update(entity);
    }

    public async Task DeletePost(PostModel post)
    {
        var entity = await _postRepo!.Get(post.Id);

        if (entity == null) throw new PostNotFoundException();

        await _postRepo.Delete(entity);
    }
}