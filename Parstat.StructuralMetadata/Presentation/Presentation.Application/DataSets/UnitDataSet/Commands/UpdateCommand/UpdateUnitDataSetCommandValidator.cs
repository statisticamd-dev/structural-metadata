using FluentValidation;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand
{
    public class UpdateUnitDataSetCommandValidator : AbstractValidator<UpdateUnitDataSetCommand>
    {
        public UpdateUnitDataSetCommandValidator()
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
