using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UpdateCommand
{
    public class UpdateStatisticalClassificationValidator : AbstractValidator<UpdateStatisticalClassificationCommand>
    {
        public UpdateStatisticalClassificationValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Description).Length(5, 255).Unless(s => string.IsNullOrEmpty(s.Description));
            RuleFor(x => x.Name).Length(5, 255);
        }
    }
}