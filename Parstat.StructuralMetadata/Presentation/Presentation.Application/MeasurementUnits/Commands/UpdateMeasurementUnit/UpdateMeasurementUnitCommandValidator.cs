using System;
using FluentValidation;

namespace Presentation.Application.MeasurementUnits.Commands.UpdateMeasurementUnit
{
    public class UpdateMeasurementUnitCommandValidator : AbstractValidator<UpdateMeasurementUnitCommand>
    {
        public UpdateMeasurementUnitCommandValidator() {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
