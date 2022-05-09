using FluentValidation;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand
{
    public class UpdateUnitDataSetCommandValidator : AbstractValidator<UpdateUnitDataSetCommand>
    {
        public UpdateUnitDataSetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.StatisticalProgramId).NotEmpty();
            RuleFor(x => x.StructureId).NotEmpty();
            RuleFor(x => x.ExchangeChannel).IsInEnum();
            RuleFor(x => x.ExchangeDirection).IsInEnum();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
