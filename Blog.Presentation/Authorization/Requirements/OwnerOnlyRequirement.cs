using Microsoft.AspNetCore.Authorization;

namespace Blog.Presentation.Authorization.Requirements;

public class OwnerOnlyRequirement : IAuthorizationRequirement
{
    public bool IsAuthor { get; }

    public OwnerOnlyRequirement(bool isAuthor) =>
        IsAuthor = isAuthor;
}
