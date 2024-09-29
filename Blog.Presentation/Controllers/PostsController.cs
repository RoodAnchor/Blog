using Blog.Logic.Models;
using Blog.Logic.Services;
using Blog.Presentation.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[ExceptionHandler]
[Route("[controller]")]
public class PostsController : Controller
{
    private readonly ILogger<PostsController> _logger;
    private readonly IPostService _postService;
    private readonly ITagService _tagService;
    private readonly IUserService _userService;

    public PostsController(
        ILogger<PostsController> logger,
        IPostService postService,
        ITagService tagService,
        IUserService userService)
    {
        _logger = logger;
        _postService = postService;
        _tagService = tagService;
        _userService = userService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> All()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var posts = await _postService.GetPosts();

        return View(posts);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Author(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var posts = await _postService.GetPostsByAuthor(id);

        return View("All", posts);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Tag(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var posts = await _postService.GetPostsByTag(id);

        return View("All", posts);
    }

    public async Task<IActionResult> Index()
    {
        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Index(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var vm = new PostViewModel();
        vm.Post = await _postService.GetPost(id);        

        vm.Post.Views++;

        await _postService.UpdatePost(vm.Post);

        return View(vm);
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Add()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var vm = new CreatePostViewModel();
        vm.Tags = await _tagService.GetTags();        

        return View(vm);
    }

    /// <summary>
    /// Создаём пост
    /// </summary>
    /// <param name="vm"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Add(CreatePostViewModel vm)
    {
        _logger.LogInformation($"Log Entry: Добавление статьи");

        vm.Post.Tags = await GetTags(vm.SelectedTagIds);
        vm.Post.User = await _userService.GetUser(User.Identity?.Name!);
        vm.Tags = await _tagService.GetTags();

        if (!ModelState.IsValid)
            return View(vm);

        await _postService.CreatePost(vm.Post);

        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("[action]/{id}")]
    [Authorize(Policy = "OwnerOnly")]
    public async Task<IActionResult> Edit(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var vm = new EditPostViewModel();

        vm.Tags = await _tagService.GetTags();
        vm.Post = await _postService.GetPost(id);

        return View(vm);
    }

    /// <summary>
    /// Обновляем пост
    /// </summary>
    /// <param name="vm"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Edit(EditPostViewModel vm)
    {
        _logger.LogInformation($"Log Entry: Редактирование статьи. ID {vm.Post.Id}");

        vm.Post.Tags = await GetTags(vm.SelectedTagIds);

        if (!ModelState.IsValid)
            return View(vm);

        await _postService.UpdatePost(vm.Post);

        return RedirectToAction("Index", new { Id = vm.Post.Id });
    }

    /// <summary>
    /// Удаляем пост
    /// </summary>
    /// <param name="vm"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Delete(PostViewModel vm)
    {
        _logger.LogInformation($"Log Entry: Удаление статьи. ID {vm.Post.Id}");

        var post = await _postService.GetPost(vm.Post.Id);

        await _postService.DeletePost(post);

        return RedirectToAction("All");
    }

    private async Task<List<TagModel>> GetTags(string selectdTags)
    {
        if (string.IsNullOrEmpty(selectdTags)) return new List<TagModel>();

        var tags = new List<TagModel>();
        var tagIds = selectdTags.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var tagId in tagIds)
        {
            var tag = await _tagService.GetTag(int.Parse(tagId));

            if (tag != null) tags.Add(tag);
        }

        return tags;
    }
}