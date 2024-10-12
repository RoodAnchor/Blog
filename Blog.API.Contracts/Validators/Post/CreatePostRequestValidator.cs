using Blog.API.Contracts.Models.Post;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Post;
public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(2000);
        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(2000);
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(10);
        RuleFor(x => x.TagIds)
            .NotEmpty();
    }
}
