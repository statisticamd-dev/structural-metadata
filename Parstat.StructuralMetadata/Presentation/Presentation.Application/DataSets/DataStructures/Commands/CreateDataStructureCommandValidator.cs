using FluentValidation;

namespace Presentation.Application.DataSets.DataStructures.Commands
{
    public class CreateDataStructureCommandValidator : AbstractValidator<CreateDataStructureCommand>
    {
        public CreateDataStructureCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}
