using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.CreateCommand
{
    public class CreateCorrespondenceValidator : AbstractValidator<CreateCorrespondenceCommand>
    {
        public CreateCorrespondenceValidator()
        {
            RuleFor(x => x.SourceId).NotEmpty();
            RuleFor(x => x.TargetId).NotEmpty();
            RuleFor(x => x.Relationship).IsInEnum();
        }
    }
}