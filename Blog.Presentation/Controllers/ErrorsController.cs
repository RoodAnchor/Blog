using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Route("[controller]")]
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ResourceNotFound()
        {
            return View();
        }
    }
}
