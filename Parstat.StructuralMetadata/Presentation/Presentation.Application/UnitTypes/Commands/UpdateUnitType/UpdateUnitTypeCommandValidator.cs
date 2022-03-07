using System;
using FluentValidation;

namespace Presentation.Application.UnitTypes.Commands.UpdateUnitType
{
    public class UpdateUnitTypeCommandValidator : AbstractValidator<UpdateUnitTypeCommand>
    {
         public UpdateUnitTypeCommandValidator() 
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 100);
        }
    }
}
