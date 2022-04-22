using FluentValidation;

namespace Presentation.Application.Variables.Commands.UpdateVariable
{
    public class UpdateVariableCommandValidator : AbstractValidator<UpdateVariableCommand>
    {
        public UpdateVariableCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Description).Length(5, 255);
            RuleFor(x => x.Definition).Length(5, 255);
            RuleFor(x => x.MeasuresId).NotEmpty();
        }
    }
}