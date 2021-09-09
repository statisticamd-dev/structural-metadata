using FluentValidation;

namespace Presentation.Application.NoteSets.CodeLists.Commands
{
    public class CreateCodeListCommandValidator : AbstractValidator<CreateCodeListCommand>
    {
        public CreateCodeListCommandValidator() 
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.Description).Length(5, 255);
        }
    }
}