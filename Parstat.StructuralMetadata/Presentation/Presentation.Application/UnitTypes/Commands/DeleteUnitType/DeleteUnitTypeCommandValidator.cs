using System;
using FluentValidation;

namespace Presentation.Application.UnitTypes.Commands.DeleteUnitType
{
    public class DeleteUnitTypeCommandValidator : AbstractValidator<DeleteUnitTypeCommand>
    {
        public DeleteUnitTypeCommandValidator() {
             RuleFor(x => x.Id).NotNull();
        }
    }
}
