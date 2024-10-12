using Blog.API.Contracts.Models.Comment;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Comment;
public class DeleteCommentRequestValidator : AbstractValidator<DeleteCommentRequest>
{
    public DeleteCommentRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
