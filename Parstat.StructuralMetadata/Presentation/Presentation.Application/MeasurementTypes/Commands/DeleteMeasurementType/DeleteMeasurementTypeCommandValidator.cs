using System;
using FluentValidation;

namespace Presentation.Application.MeasurementTypes.Commands.DeleteMeasurementType
{
    public class DeleteMeasurementTypeCommandValidator : AbstractValidator<DeleteMeasurementTypeCommand>
    {
        
        public DeleteMeasurementTypeCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
