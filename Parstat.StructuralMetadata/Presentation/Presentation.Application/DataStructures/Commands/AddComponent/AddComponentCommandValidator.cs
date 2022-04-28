using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.AddComponent
{
    public class AddComponentCommandValidator : AbstractValidator<AddComponentCommand>
    {
        public AddComponentCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.DataStructureId).GreaterThan(0);
        }
    }
}
