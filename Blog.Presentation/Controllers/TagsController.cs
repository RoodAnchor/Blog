using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class TagsController : Controller
{
    private readonly ILogger<TagsController> _logger;
    private readonly ITagService _tagService;

    public TagsController(
        ILogger<TagsController> logger,
        ITagService tagService)
    {
        _logger = logger;
        _tagService = tagService;
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

        var tag = await _tagService.GetTag(id);

        return View(tag);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> All()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var tags = await _tagService.GetTags();

        return View(tags);
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Add()
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        return View(new TagModel());
    }

    /// <summary>
    /// Создаём новый тэг
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> Add(TagModel tag)
    {
        if (!ModelState.IsValid)
            return View(tag);

        await _tagService.CreateTag(tag);

        _logger.LogInformation($"Log Entry: Создание тега. Name: {tag.Name}");

        return RedirectToAction("All");
    }

    [HttpGet]
    [Route("[action]/{id}")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Edit(int id)
    {
        _logger.LogInformation($"Log Entry: Просмотр страницы {Request.Path}");

        var tag = await _tagService.GetTag(id);

        return View(tag);
    }

    /// <summary>
    /// Обновляем тэг
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Edit(TagModel tag)
    {
        if (!ModelState.IsValid)
            return View(tag);

        _logger.LogInformation($"Log Entry: Редактирование тега. ID: {tag.Id}");

        await _tagService.UpdateTag(tag);

        return RedirectToAction("Index", new { Id = tag.Id });
    }

    /// <summary>
    /// Удаляем тэг
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Администратор,Модератор")]
    public async Task<IActionResult> Delete(TagModel tag)
    {
        _logger.LogInformation($"Log Entry: Удаление тега. ID: {tag.Id}");

        await _tagService.DeleteTag(tag.Id);

        return RedirectToAction("All");
    }
}