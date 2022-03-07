using FluentValidation;

namespace Presentation.Application.MeasurementTypes.Commands.CreateMeasurementType
{
    public class CreateMeasurementTypeCommandValidator : AbstractValidator<CreateMeasurementTypeCommand>
    {
        public CreateMeasurementTypeCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.Description).Length(5, 255);
        }
    }
}