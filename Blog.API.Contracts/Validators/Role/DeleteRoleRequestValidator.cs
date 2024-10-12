using Blog.API.Contracts.Models.Role;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Role;
public class DeleteRoleRequestValidator : AbstractValidator<DeleteRoleRequest>
{
    public DeleteRoleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}