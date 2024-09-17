using Blog.Logic.Services;
using Blog.Presentation.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Blog.Presentation.Authorization.Handlers
{
    public class OwnerOnlyHandler : AuthorizationHandler<OwnerOnlyRequirement>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        public OwnerOnlyHandler(
            IPostService postService,
            IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            OwnerOnlyRequirement requirement)
        {

            var isAuthor = await IsOwner(context.User, context.Resource);
            var isInRoles = context.User.IsInRole("Администратор") || context.User.IsInRole("Модератор");

            if (isAuthor || isInRoles)
                context.Succeed(requirement);

            return;
        }

        private async Task<bool> IsOwner(ClaimsPrincipal user, object? resource)
        {
            var httpReq = ((DefaultHttpContext)resource!).Request;
            var controller = httpReq.RouteValues["controller"];
            var id = int.Parse(httpReq.RouteValues["id"]?.ToString()!);

            switch (controller)
            {
                case "Posts":
                    var postEntity = await _postService.GetPost(id);

                    if (user.Identity?.Name == postEntity.User?.Email)
                        return true;

                    break;

                case "Users":
                    var userEntity = await _userService.GetUser(id);

                    if(user.Identity?.Name == userEntity.Email)
                        return true;

                    break;
            }

            return false;
        }
    }
}
