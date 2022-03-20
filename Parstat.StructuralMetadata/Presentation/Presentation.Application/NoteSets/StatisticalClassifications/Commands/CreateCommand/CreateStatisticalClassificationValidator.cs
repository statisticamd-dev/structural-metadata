using FluentValidation;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Commands.CreateCommand
{
    public class CreateStatisticalClassificationValidator : AbstractValidator<CreateStatisticalClassificationCommand>
    {
        public CreateStatisticalClassificationValidator()
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Description).Length(5, 255);
            RuleFor(x => x.Definition).Length(5, 255);            
        }
    }
}