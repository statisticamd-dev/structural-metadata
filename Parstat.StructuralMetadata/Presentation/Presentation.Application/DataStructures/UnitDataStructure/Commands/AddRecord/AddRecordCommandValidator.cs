using FluentValidation;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.AddRecord
{
    public class AddRecordCommandValidator : AbstractValidator<AddRecordCommand>
    {
        public AddRecordCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.ParentId).NotEmpty().When(x => x.ParentId != null);
            RuleFor(x => x.DataStructureId).NotEmpty();
        }
    }
}
