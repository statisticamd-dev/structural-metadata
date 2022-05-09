using FluentValidation;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand
{
    public class UpdateUnitDataSetCommandValidator : AbstractValidator<UpdateUnitDataSetCommand>
    {
        public UpdateUnitDataSetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.StatisticalProgramId).NotNull().GreaterThan(0);
            RuleFor(x => x.StructureId).NotNull().GreaterThan(0);
            RuleFor(x => x.ExchangeChannel).IsInEnum();
            RuleFor(x => x.ExchangeDirection).IsInEnum();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}
