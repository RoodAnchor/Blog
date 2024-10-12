using Blog.API.Contracts.Models.Tag;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Tag;
public class CreateTagRequestValidator : AbstractValidator<CreateTagRequest>
{
    public CreateTagRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
    }
}
