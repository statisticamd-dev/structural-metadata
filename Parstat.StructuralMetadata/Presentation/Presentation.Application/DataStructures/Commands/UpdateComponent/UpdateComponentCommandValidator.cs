using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.UpdateComponent
{
    public class UpdateComponentCommandValidator : AbstractValidator<UpdateComponentCommand>
    {
        public UpdateComponentCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.DataStructureId).GreaterThan(0);
        }
    }
}