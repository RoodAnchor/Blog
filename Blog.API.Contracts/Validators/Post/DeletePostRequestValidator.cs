using Blog.API.Contracts.Models.Post;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Post;
public class DeletePostRequestValidator : AbstractValidator<DeletePostRequest>
{
    public DeletePostRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
