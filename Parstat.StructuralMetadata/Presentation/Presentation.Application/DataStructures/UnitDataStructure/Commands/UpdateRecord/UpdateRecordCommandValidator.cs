using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.UpdateRecord
{
    public class UpdateRecordCommandValidator : AbstractValidator<UpdateRecordCommand>
    {
        public UpdateRecordCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.ParentId).NotEmpty().When(x => x.ParentId != null);
            RuleFor(x => x.DataStructureId).NotEmpty();
        }
    }
}