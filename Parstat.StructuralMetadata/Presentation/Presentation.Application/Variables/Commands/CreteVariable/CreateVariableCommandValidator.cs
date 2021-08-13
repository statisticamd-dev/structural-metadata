using FluentValidation;

namespace Presentation.Application.Variables.Commands.CreteVariable
{
    public class CreateVariableCommandValidator : AbstractValidator<CreateVariableCommand>
    {
        public CreateVariableCommandValidator()
        {
            RuleFor(x => x.LocalId).Length(3, 100).NotEmpty();
            RuleFor(x => x.Description).Length(5, 255);
            RuleFor(x => x.Definition).Length(5, 255);
            RuleFor(x => x.MeasuresId).NotEmpty();
        }
    }
}