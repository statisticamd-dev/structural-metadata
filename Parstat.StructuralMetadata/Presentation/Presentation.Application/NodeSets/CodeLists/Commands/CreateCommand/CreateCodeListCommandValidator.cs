using FluentValidation;

namespace Presentation.Application.NodeSets.CodeLists.Commands.CreateCommand
{
    public class CreateCodeListCommandValidator : AbstractValidator<CreateCodeListCommand>
    {
        public CreateCodeListCommandValidator() 
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}