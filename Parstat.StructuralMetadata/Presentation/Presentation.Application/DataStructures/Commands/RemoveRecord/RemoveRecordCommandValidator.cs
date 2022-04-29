using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.RemoveRecord
{
    public class RemoveRecordCommandValidator : AbstractValidator<RemoveRecordCommand>
    {
        public RemoveRecordCommandValidator()
        {
            RuleFor(x => x.DataStructureId).GreaterThan(0);
            RuleFor(x => x.RecordId).GreaterThan(0);
        }
    }
}
