using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        /// <summary>
        /// Регистрация пользоваталя
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task SignUp(UserModel user)
        {
            await _userService.RegisterUser(user);
        }

        /// <summary>
        /// Получаем пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<UserModel> GetUser(int id)
        {
            return await _userService.GetUser(id);
        }

        /// <summary>
        /// Получаем всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<List<UserModel>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        /// <summary>
        /// Обвновляем пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task Edit(UserModel user)
        {
            await _userService.UpdateUser(user);
        }

        /// <summary>
        /// Удаляем пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task Delete(UserModel user)
        {
            await _userService.DeleteUser(user);
        }
    }
}
