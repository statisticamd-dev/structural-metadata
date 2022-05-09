using FluentValidation;

namespace Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit
{
    public class CreateMeasurementUnitCommandValidator : AbstractValidator<CreateMeasurementUnitCommand>
    {
        public CreateMeasurementUnitCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}