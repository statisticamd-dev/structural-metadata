using System;
using FluentValidation;

namespace Presentation.Application.MeasurementUnits.Commands.DeleteMeasurementUnit
{
    public class DeleteMeasurementUnitCommandValidator : AbstractValidator<DeleteMeasurementUnitCommand>
    {
        public DeleteMeasurementUnitCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
