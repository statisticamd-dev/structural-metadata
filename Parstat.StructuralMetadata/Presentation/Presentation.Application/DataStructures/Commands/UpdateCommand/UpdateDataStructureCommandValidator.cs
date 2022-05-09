using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.UpdateCommand
{
    public class UpdateDataStructureCommandValidator : AbstractValidator<UpdateDataStructureCommand>
    {
        public UpdateDataStructureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
