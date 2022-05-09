using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UpdateLevelCommand
{
    public class UpdateStatisticalClassificationLevelCommandValidator : AbstractValidator<UpdateStatisticalClassificationLevelCommand>
    {
        public UpdateStatisticalClassificationLevelCommandValidator() 
        {
            RuleFor(x => x.StatisticalClassificationId).NotEmpty();
            RuleFor(x => x.LevelId).NotEmpty();
        }
    }
}
