using System;
using FluentValidation;

namespace Presentation.Application.RepresentedVariables.Commands.DeleteCommand
{
    public class DeleteRepresentedVariableCommandValidator :  AbstractValidator<DeleteRepresentedVariableCommand>
    {
        public DeleteRepresentedVariableCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
