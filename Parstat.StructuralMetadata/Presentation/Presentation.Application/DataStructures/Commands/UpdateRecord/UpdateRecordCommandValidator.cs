using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.UpdateRecord
{
    public class UpdateRecordCommandValidator : AbstractValidator<UpdateRecordCommand>
    {
        public UpdateRecordCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.ParentId).GreaterThan(0).When(x => x.ParentId != null);
            RuleFor(x => x.DataStructureId).GreaterThan(0);
        }
    }
}