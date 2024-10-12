using AutoMapper;
using Blog.API.Contracts.Models.Post;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private IPostService _postService;
    private IUserService _userService;
    private ITagService _tagService;
    private IMapper _mapper;

    public PostController(
        IPostService postService,
        IUserService userService,
        ITagService tagService,
        IMapper mapper)
    {
        _postService = postService;
        _userService = userService;
        _tagService = tagService;
        _mapper = mapper;
    }

    #region Create
    [HttpPost]
    [Route("[action]")]
    public async Task Create([FromBody] CreatePostRequest newPost)
    {
        var user = await _userService.GetUser(newPost.UserId);
        var tags = (await _tagService.GetTags()).Where(x => newPost.TagIds.Contains(x.Id));
        var post = _mapper.Map<PostModel>(newPost);

        post.Tags = tags.ToList();
        post.User = user;

        await _postService.CreatePost(post);
    }
    #endregion Create

    #region Read
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<GetPostResponse> GetById(int id)
    {
        var post = await _postService.GetPost(id);

        return _mapper.Map<GetPostResponse>(post);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IEnumerable<GetPostResponse>> GetAll()
    {
        var posts = await _postService.GetPosts();

        return _mapper.Map<IEnumerable<GetPostResponse>>(posts);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IEnumerable<GetPostResponse>> GetByAuthorId(int id)
    {
        var posts = await _postService.GetPostsByAuthor(id);

        return _mapper.Map<IEnumerable<GetPostResponse>>(posts);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IEnumerable<GetPostResponse>> GetByTagId(int id)
    { 
        var posts = await _postService.GetPostsByTag(id);

        return _mapper.Map<IEnumerable<GetPostResponse>>(posts);
    }
    #endregion Read

    #region Update
    [HttpPut]
    [Route("[action]")]
    public async Task Update([FromBody] UpdatePostRequest updatePost) 
    {
        var post = _mapper.Map<PostModel>(updatePost);
        var tags = (await _tagService.GetTags()).Where(x => updatePost.TagIds.Contains(x.Id));

        post.Tags = tags.ToList();

        await _postService.UpdatePost(post);
    }
    #endregion Update

    #region Delete
    [HttpDelete]
    [Route("[action]")]
    public async Task Delete([FromBody] DeletePostRequest postToDelete)
    {
        var post = _mapper.Map<PostModel>(postToDelete);

        await _postService.DeletePost(post);

    }
    #endregion Delete
}