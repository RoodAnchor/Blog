using Blog.API.Contracts.Models.Tag;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Tag;
public class UpdateTagRequestValidator : AbstractValidator<UpdateTagRequest>
{
    public UpdateTagRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
    }
}
