using System;
using FluentValidation;
using Presentation.Application.RepresentedVariables.Commands.UpdateRepresentedVariable;

namespace Presentation.Application.Variables.Commands.UpdateRepresentedVariable
{
    public class UpdateRepresentedVariableCommandValidator : AbstractValidator<UpdateRepresentationVariableCommand>
    {
        public UpdateRepresentedVariableCommandValidator()
        {
            //The description validation is passed in case the description is null or the provided value is between 4 & 256
            RuleFor(x => x.Description).MinimumLength(3).When(x => !String.IsNullOrEmpty(x.Description));
            RuleFor(x => x.Name).MinimumLength(3).When(x => !String.IsNullOrEmpty(x.Name));
            RuleFor(x => x.VariableId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();            
        }
    }
}