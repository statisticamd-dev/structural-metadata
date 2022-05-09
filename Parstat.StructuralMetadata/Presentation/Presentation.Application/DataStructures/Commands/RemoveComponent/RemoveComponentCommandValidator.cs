using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.RemoveComponent
{
    public class RemoveComponentCommandValidator : AbstractValidator<RemoveComponentCommand>
    {
        public RemoveComponentCommandValidator()
        {
            RuleFor(x => x.DataStructureId).NotEmpty();
            RuleFor(x => x.ComponentId).NotEmpty();
        }
    }
}
