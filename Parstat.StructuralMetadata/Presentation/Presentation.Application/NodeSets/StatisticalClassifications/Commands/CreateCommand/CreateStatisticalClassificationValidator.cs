using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.CreateCommand
{
    public class CreateStatisticalClassificationValidator : AbstractValidator<CreateStatisticalClassificationCommand>
    {
        public CreateStatisticalClassificationValidator()
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Name).Length(3, 100);          
        }
    }
}