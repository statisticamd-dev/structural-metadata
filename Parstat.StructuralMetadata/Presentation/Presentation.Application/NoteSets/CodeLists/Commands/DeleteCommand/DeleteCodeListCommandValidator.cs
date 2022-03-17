using System;
using FluentValidation;

namespace Presentation.Application.MeasurementUnits.Commands.DeleteMeasurementUnit
{
    public class DeleteCodeListCommandValidator : AbstractValidator<DeleteCodeListCommand>
    {
        public DeleteCodeListCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
