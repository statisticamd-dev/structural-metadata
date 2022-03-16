using FluentValidation;
using Presentation.Application.RepresentedVariables.Commands.UpdateRepresentedVariable;

namespace Presentation.Application.Variables.Commands.UpdateRepresentedVariable
{
    public class UpdateRepresentedVariableCommandValidator : AbstractValidator<UpdateRepresentationVariableCommand>
    {
        public UpdateRepresentedVariableCommandValidator()
        {
            //The description validation is passed in case the description is null or the provided value is between 4 & 256
            RuleFor(x => x.Description).Must(x => x == null || (x.Length >= 5 && x.Length <=255));
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.VariableId).NotEmpty();
            RuleFor(x => x.LocalId).NotEmpty();            
        }
    }
}