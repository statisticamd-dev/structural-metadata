using System;
using FluentValidation;

namespace Presentation.Application.MeasurementTypes.Commands.UpdateMeasurementType
{
    public class UpdateMeasurementTypeCommandValidator : AbstractValidator<UpdateMeasurementTypeCommand>
    {
        
        public UpdateMeasurementTypeCommandValidator() {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 100);
        }
    }
}
