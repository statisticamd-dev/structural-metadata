using FluentValidation;

namespace Presentation.Application.DataSets.DimansionalDataSet.Commands.CreateCommand
{
    public class CreateDimensionalDataSetCommandValidator : AbstractValidator<CreateDimensionalDataSetCommand>
    {
        public CreateDimensionalDataSetCommandValidator()
        {
            RuleFor(x => x.LocalId).MinimumLength(1).NotEmpty();
            RuleFor(x => x.StatisticalProgramId).NotEmpty();
            RuleFor(x => x.StructureId).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }            
    }
}
