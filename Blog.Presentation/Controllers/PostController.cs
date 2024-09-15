using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly ITagService _tagService;

    public PostController(
        IPostService postService,
        ITagService tagService)
    {
        _postService = postService;
        _tagService = tagService;
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult Create()
    {
        var vm = new CreatePostViewModel();
        vm.Tags = _tagService.GetTags();

        return View(vm);
    }

    /// <summary>
    /// Создаём пост
    /// </summary>
    /// <param name="vm"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Create(CreatePostViewModel vm)
    {
        var tagIds = vm.SelectedTagIds.Split(',');

        foreach (var tagId in tagIds)
        {
            var tag = await _tagService.GetTag(int.Parse(tagId));

            if (tag != null) vm.Post.Tags.Add(tag);
        }

        await _postService.CreatePost(vm.Post);
    }

    /// <summary>
    /// Получаем все посты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<List<PostModel>> Get()
    {
        return _postService.GetPosts();
    }

    /// <summary>
    /// Получаем все посты автора
    /// </summary>
    /// <param name="authorId">ИД автора</param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{authorId}")]
    public async Task<List<PostModel>> Get(int authorId)
    {
        return _postService.GetPosts(authorId);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _postService.GetPost(id);

        return View(post);
    }

    /// <summary>
    /// Обновляем пост
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Edit(PostModel post)
    {
        await _postService.UpdatePost(post);

        return View(post.Id);
    }

    /// <summary>
    /// Удаляем пост
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Delete(PostModel post)
    {
        await _postService.DeletePost(post);
    }
}