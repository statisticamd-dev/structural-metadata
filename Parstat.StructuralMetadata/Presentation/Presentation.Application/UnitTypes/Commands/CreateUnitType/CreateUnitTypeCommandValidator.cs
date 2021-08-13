using FluentValidation;

namespace Presentation.Application.UnitTypes.Commands.CreateUnitType
{
    public class CreateUnitTypeCommandValidator : AbstractValidator<CreateUnitTypeCommand>
    {
        public CreateUnitTypeCommandValidator() 
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Name).Length(3, 100).NotEmpty();
        }
    }
}