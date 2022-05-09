using FluentValidation;

namespace Presentation.Application.Concepts.Commands.UpdateConcept
{
    public class UpdateConceptCommandValidator : AbstractValidator<UpdateConceptCommand>
    {
        public UpdateConceptCommandValidator() {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
