using FluentValidation;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Commands.UpdateCommand
{
    public class UpdateStatisticalClassificationValidator : AbstractValidator<UpdateStatisticalClassificationCommand>
    {
        public UpdateStatisticalClassificationValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Description).Must(x => x == null || (x.Length >= 5 && x.Length <= 255));
            RuleFor(x => x.Definition).Must(x => x == null || (x.Length >= 5 && x.Length <= 255));
        }
    }
}