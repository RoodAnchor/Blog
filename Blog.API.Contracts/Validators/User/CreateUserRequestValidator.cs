using Blog.API.Contracts.Models.User;
using FluentValidation;

namespace Blog.API.Contracts.Validators.User;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.SecondName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        RuleFor(x => x.BirthDate).NotEmpty();
    }
}
