using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.AddStatisticalClassificationLevelCommand
{
    public class AddStatisticalClassificationLevelValidator : AbstractValidator<AddStatisticalClassificationLevelCommand>
    {
        public AddStatisticalClassificationLevelValidator()
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Description).Length(5, 255).Unless(s => string.IsNullOrEmpty(s.Description));
            RuleFor(x => x.Name).Length(5, 255);
        }
    }
}