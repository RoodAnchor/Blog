using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[Route("[controller]")]
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        return View(new TagModel());
    }

    /// <summary>
    /// Создаём новый тэг
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Create(TagModel tag)
    {
        await _tagService.CreateTag(tag);
    }

    /// <summary>
    /// Получаем тэг по ид
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<TagModel> Get(int id)
    {
        return await _tagService.GetTag(id);
    }

    /// <summary>
    /// Получаем все тэги
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<List<TagModel>> Get()
    {
        return _tagService.GetTags();
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
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
    public async Task<IActionResult> Edit(TagModel tag)
    {
        await _tagService.UpdateTag(tag);

        return View(tag.Id);
    }

    /// <summary>
    /// Удаляем тэг
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task Delete(TagModel tag)
    {
        await _tagService.DeleteTag(tag);
    }
}