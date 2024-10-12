using Blog.API.Contracts.Models.Comment;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Comment;
public class UpdateCommentRequestValidator : AbstractValidator<UpdateCommentRequest>
{
    public UpdateCommentRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(2000);
    }
}
