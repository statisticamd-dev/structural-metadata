using FluentValidation;

namespace Presentation.Application.DataSets.UnitDataSet.Commands.DeleteCommand
{
    class DeleteUnitDataSetCommandValidator : AbstractValidator<DeleteUnitDataSetCommand>
    {
        public DeleteUnitDataSetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}