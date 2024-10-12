using Blog.API.Contracts.Models.User;
using FluentValidation;

namespace Blog.API.Contracts.Validators.User;
public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
