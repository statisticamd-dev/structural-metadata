using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand
{
    public class CreateUnitDataSetCommandValidator : AbstractValidator<CreateUnitDataSetCommand>
    {
        public CreateUnitDataSetCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.StatisticalProgramId).NotNull().GreaterThan(0);
            RuleFor(x => x.StructureId).NotNull().GreaterThan(0);
            RuleFor(x => x.ExchangeChannel).NotNull().NotEmpty();
            RuleFor(x => x.ExchangeDirection).NotNull().NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}
