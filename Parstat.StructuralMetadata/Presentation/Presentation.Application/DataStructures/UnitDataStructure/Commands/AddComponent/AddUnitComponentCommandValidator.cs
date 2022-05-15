using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.AddComponent
{
    public class AddUnitComponentCommandValidator : AbstractValidator<AddUnitComponentCommand>
    {
        public AddUnitComponentCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.DataStructureId).NotEmpty();
        }
    }
}
