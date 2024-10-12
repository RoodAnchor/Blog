using Blog.API.Contracts.Models.Role;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Role;
public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
    }
}
