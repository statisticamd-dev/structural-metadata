using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.RemoveComponent
{
    public class RemoveUnitComponentCommandValidator : AbstractValidator<RemoveUnitComponentCommand>
    {
        public RemoveUnitComponentCommandValidator()
        {
            RuleFor(x => x.UnitDataStructureId).NotEmpty();
            RuleFor(x => x.UnitComponentId).NotEmpty();
        }
    }
}
