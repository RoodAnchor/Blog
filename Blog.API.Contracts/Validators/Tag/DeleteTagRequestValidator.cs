using Blog.API.Contracts.Models.Tag;
using FluentValidation;

namespace Blog.API.Contracts.Validators.Tag;
public class DeleteTagRequestValidator : AbstractValidator<DeleteTagRequest>
{
    public DeleteTagRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
