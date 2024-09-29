using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Presentation.Utils;

namespace Blog.Presentation.Controllers;

[ExceptionHandler]
[Route("[controller]")]
public class CommentsController : Controller
{
    private readonly ILogger<CommentsController> _logger;
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;

    public CommentsController(
        ILogger<CommentsController> logger,
        ICommentService commentService,
        IUserService userService)
    {
        _logger = logger;
        _commentService = commentService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Index(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var comment = await _commentService.GetComment(id);

        return View(comment);
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> All()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var comments = _commentService.GetComments();

        return View(comments);
    }

    /// <summary>
    /// Создаём коммент
    /// </summary>
    /// <param name="vm"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Add(PostViewModel vm)
    {
        _logger.LogInformation($"Log Entry: Добавление комментария");

        var user = await _userService.GetUser(User.Identity?.Name!);
        var comment = vm.Comment;

        comment.UserId = user.Id;
        comment.PostId = vm.Post.Id;

        if (!ModelState.IsValid)
        {
            var message = ModelState["Comment.Content"]?.Errors[0].ErrorMessage.ToString();
            TempData["CommentValidationErrorMessage"] = message;

            return RedirectToAction("Index", "Posts", new { Id = vm.Post.Id });
        }

        await _commentService.CreateComment(comment);

        return RedirectToAction("Index", "Posts", new { id = comment.PostId });
    }

    [HttpGet]
    [Route("[action]/{id}")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Edit(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var comment = await _commentService.GetComment(id);

        return View(comment);
    }

    /// <summary>
    /// Обновляем коммент
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Edit(CommentModel comment)
    {
        _logger.LogInformation($"Log Entry: Обновление комментария. ID: {comment.Id}");

        if (!ModelState.IsValid)
            return View(comment);

        await _commentService.UpdateComment(comment);

        return RedirectToAction("Index", new { Id = comment.Id });
    }

    /// <summary>
    /// Удаляем коммент
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Delete(CommentModel comment)
    {
        _logger.LogInformation($"Log Entry: Удаление комментария. ID: {comment.Id}");

        await _commentService.DeleteComment(comment);

        return RedirectToAction("All");
    }
}