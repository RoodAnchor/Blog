using Blog.API.Contracts.Models.Comment;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Comment;
public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(2000);
    }
}
