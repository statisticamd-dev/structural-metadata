using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.UpdateComponent
{
    public class UpdateComponentCommandValidator : AbstractValidator<UpdateComponentCommand>
    {
        public UpdateComponentCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.DataStructureId).NotEmpty();
        }
    }
}