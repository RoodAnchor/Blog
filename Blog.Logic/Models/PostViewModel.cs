using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Blog.Logic.Models
{
    public class PostViewModel
    {
        [ValidateNever]
        public PostModel? Post { get; set; }
        public CommentModel? Comment { get; set; }
    }
}
