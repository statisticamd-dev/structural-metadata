using FluentValidation;

namespace Presentation.Application.Variables.Commands.CreteVariable
{
    public class CreateVariableCommandValidator : AbstractValidator<CreateVariableCommand>
    {
        public CreateVariableCommandValidator()
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Name).Length(3, 255);
            RuleFor(x => x.MeasuresId).NotEmpty();
        }
    }
}