using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateComponent
{
    public class UpdateUnitComponentCommandValidator : AbstractValidator<UpdateUnitComponentCommand>
    {
        public UpdateUnitComponentCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.DataStructureId).NotEmpty();
        }
    }
}