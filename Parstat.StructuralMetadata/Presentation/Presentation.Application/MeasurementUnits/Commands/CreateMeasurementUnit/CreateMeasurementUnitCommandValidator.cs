using FluentValidation;

namespace Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit
{
    public class CreateMeasurementUnitCommandValidator : AbstractValidator<CreateMeasurementUnitCommand>
    {
        public CreateMeasurementUnitCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            //RuleFor(x => x.Description).Length(5, 255);
            //RuleFor(x => x.MeasurementTypeId).NotEmpty();
        }
    }
}