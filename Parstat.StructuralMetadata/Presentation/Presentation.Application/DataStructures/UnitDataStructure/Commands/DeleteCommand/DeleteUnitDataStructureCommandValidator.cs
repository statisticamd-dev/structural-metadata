using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.DeleteCommand
{
    class DeleteUnitDataStructureCommandValidator : AbstractValidator<DeleteUnitDataStructureCommand>
    {
        public DeleteUnitDataStructureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}