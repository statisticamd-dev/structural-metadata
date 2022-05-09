using FluentValidation;

namespace Presentation.Application.Concepts.Commands.CreateConcept
{
    public class CreateConceptCommandValidator : AbstractValidator<CreateConceptCommand>
    {
        public CreateConceptCommandValidator() {
            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotNull();
        }
    }
}
