using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Создаём пост
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task CreatePost(PostModel post)
        {
            await _postService.CreatePost(post);    
        }

        /// <summary>
        /// Получаем все посты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles="Администратор")]
        public async Task<List<PostModel>> GetPosts()
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
        public async Task<List<PostModel>> GetPosts(int authorId)
        {
            return _postService.GetPosts(authorId);
        }

        /// <summary>
        /// Обновляем пост
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task Edit(PostModel post)
        {
            await _postService.UpdatePost(post);
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
}
