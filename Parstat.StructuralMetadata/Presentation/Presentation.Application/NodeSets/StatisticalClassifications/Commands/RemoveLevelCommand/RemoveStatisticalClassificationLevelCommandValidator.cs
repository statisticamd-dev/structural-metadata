using System;
using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.RemoveLevelCommand
{
    public class RemoveStatisticalClassificationLevelCommandValidator : AbstractValidator<RemoveStatisticalClassificationLevelCommand>
    {
        public RemoveStatisticalClassificationLevelCommandValidator() 
        {
            RuleFor(x => x.StatisticalClassificationId).NotEmpty();
            RuleFor(x => x.LevelId).NotEmpty();
        }
    }
}
