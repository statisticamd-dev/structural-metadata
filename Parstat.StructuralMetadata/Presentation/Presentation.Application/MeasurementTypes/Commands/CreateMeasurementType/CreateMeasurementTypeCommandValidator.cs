using FluentValidation;

namespace Presentation.Application.MeasurementTypes.Commands.CreateMeasurementType
{
    public class CreateMeasurementTypeCommandValidator : AbstractValidator<CreateMeasurementTypeCommand>
    {
        public CreateMeasurementTypeCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}