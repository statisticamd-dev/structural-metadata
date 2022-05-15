using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.CreateCommand
{
    public class CreateUnitDataStructureCommandValidator : AbstractValidator<CreateUnitDataStructureCommand>
    {
        public CreateUnitDataStructureCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
