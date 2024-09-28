using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class CommentsController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;

    public CommentsController(
        ICommentService commentService,
        IUserService userService)
    {
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
        var comment = await _commentService.GetComment(id);

        return View(comment);
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> All()
    {
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
        await _commentService.DeleteComment(comment);

        return RedirectToAction("All");
    }
}