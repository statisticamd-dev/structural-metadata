using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.AddComponent
{
    public class AddComponentCommandValidator : AbstractValidator<AddComponentCommand>
    {
        public AddComponentCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.DataStructureId).NotEmpty();
        }
    }
}
