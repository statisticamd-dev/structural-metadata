using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.UpdateCommand
{
    public class UpdateDataStructureCommandValidator : AbstractValidator<UpdateDataStructureCommand>
    {
        public UpdateDataStructureCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.Group).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}
