using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    /// <summary>
    /// Создаём коммент
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task CreateComment(CommentModel comment)
    {
        await _commentService.CreateComment(comment);
    }

    /// <summary>
    /// Получаем один коммента по ид
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<CommentModel> GetComment(int id)
    {
        return await _commentService.GetComment(id);
    }

    /// <summary>
    /// Получаем все комменты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<List<CommentModel>> GetComments()
    {
        return _commentService.GetComments();
    }

    /// <summary>
    /// Обновляем коммент
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Edit(CommentModel comment)
    {
        await _commentService.UpdateComment(comment);
    }

    /// <summary>
    /// Удаляем коммент
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Delete(CommentModel comment)
    {
        await _commentService.DeleteComment(comment);
    }
}