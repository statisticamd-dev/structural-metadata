using System;
using FluentValidation;

namespace Presentation.Application.Variables.Commands.UpdateVariable
{
    public class UpdateVariableCommandValidator : AbstractValidator<UpdateVariableCommand>
    {
        public UpdateVariableCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).When(x => !String.IsNullOrEmpty(x.Description));
            RuleFor(x => x.Description).MinimumLength(5).When(x => !String.IsNullOrEmpty(x.Description));
        }
    }
}