using FluentValidation;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand
{
    public class CreateUnitDataSetCommandValidator : AbstractValidator<CreateUnitDataSetCommand>
    {
        public CreateUnitDataSetCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.StatisticalProgramId).NotEmpty();
            RuleFor(x => x.StructureId).NotEmpty();
            RuleFor(x => x.ExchangeChannel).IsInEnum();
            RuleFor(x => x.ExchangeDirection).IsInEnum();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
