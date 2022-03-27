using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.CreateCommand
{
    public class CreateCorrespondenceValidator : AbstractValidator<CreateCorrespondenceCommand>
    {
        public CreateCorrespondenceValidator()
        {
            RuleFor(x => x.SourceId).GreaterThan(0);
            RuleFor(x => x.TargetId).GreaterThan(0);
            RuleFor(x => x.Relationship).IsInEnum();
        }
    }
}