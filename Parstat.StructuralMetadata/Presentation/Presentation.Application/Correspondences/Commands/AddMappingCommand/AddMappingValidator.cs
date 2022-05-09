using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.AddMappingCommand
{
    public class AddMappingValidator : AbstractValidator<AddMappingCommand>
    {
        public AddMappingValidator()
        {
            RuleFor(x => x.SourceId).NotEmpty();
            RuleFor(x => x.TargetId).NotEmpty();
            RuleFor(x => x.SourceId).NotEqual(x => x.TargetId);
            RuleFor(x => x.CorrespondenceId).NotEmpty();
        }
    }
}