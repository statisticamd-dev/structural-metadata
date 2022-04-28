using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.AddRecord
{
    public class AddRecordCommandValidator : AbstractValidator<AddRecordCommand>
    {
        public AddRecordCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.ParentId).GreaterThan(0).When(x => x.ParentId != null);
            RuleFor(x => x.DataStructureId).GreaterThan(0);
        }
    }
}
