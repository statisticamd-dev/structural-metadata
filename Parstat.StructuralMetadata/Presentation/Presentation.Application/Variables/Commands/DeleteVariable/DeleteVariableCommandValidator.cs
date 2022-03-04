using FluentValidation;
using Presentation.Application.Variables.Commands.DeleteVariable;

namespace Presentation.Application.Variables.Commands.CreteVariable
{
    public class DeleteVariableCommandValidator : AbstractValidator<DeleteVariableCommand>
    {
        public DeleteVariableCommandValidator()
        {            
            RuleFor(x => x.Id).NotNull();           
        }
    }
}