using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.RemoveComponent
{
    public class RemoveComponentCommandValidator : AbstractValidator<RemoveComponentCommand>
    {
        public RemoveComponentCommandValidator()
        {
            RuleFor(x => x.DataStructureId).GreaterThan(0);
            RuleFor(x => x.ComponentId).GreaterThan(0);
        }
    }
}
