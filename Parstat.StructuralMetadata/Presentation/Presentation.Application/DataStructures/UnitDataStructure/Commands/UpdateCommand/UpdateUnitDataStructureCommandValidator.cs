using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateCommand
{
    public class UpdateUnitDataStructureCommandValidator : AbstractValidator<UpdateUnitDataStructureCommand>
    {
        public UpdateUnitDataStructureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
