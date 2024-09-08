using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Создаём новый тэг
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task CreateTag(TagModel tag)
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
        public async Task<TagModel> GetTag(int id)
        {
            return await _tagService.GetTag(id);
        }

        /// <summary>
        /// Получаем все тэги
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<List<TagModel>> GetTags()
        {
            return _tagService.GetTags();
        }

        /// <summary>
        /// Обновляем тэг
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task Edit(TagModel tag)
        {
            await _tagService.UpdateTag(tag);
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
}
