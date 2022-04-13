using System;
using FluentValidation;

namespace Presentation.Application.Concepts.Commands.DeleteConcept
{
    public class DeleteConceptCommandValidator : AbstractValidator<DeleteConceptCommand>
    {
        public DeleteConceptCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
