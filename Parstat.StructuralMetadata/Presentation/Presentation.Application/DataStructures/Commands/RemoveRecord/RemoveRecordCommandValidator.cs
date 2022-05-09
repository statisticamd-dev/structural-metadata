using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.RemoveRecord
{
    public class RemoveRecordCommandValidator : AbstractValidator<RemoveRecordCommand>
    {
        public RemoveRecordCommandValidator()
        {
            RuleFor(x => x.DataStructureId).NotEmpty();
            RuleFor(x => x.RecordId).NotEmpty();
        }
    }
}
