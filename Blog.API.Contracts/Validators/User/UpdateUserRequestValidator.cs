using Blog.API.Contracts.Models.User;
using FluentValidation;

namespace Blog.API.Contracts.Validators.User;
public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.SecondName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        RuleFor(x => x.RoleIds).NotEmpty();
    }
}
