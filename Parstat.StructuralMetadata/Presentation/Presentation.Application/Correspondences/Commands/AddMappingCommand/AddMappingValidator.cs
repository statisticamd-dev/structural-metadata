using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.AddMappingCommand
{
    public class AddMappingValidator : AbstractValidator<AddMappingCommand>
    {
        public AddMappingValidator()
        {
            RuleFor(x => x.SourceId).GreaterThan(0);
            RuleFor(x => x.TargetId).GreaterThan(0);
            RuleFor(x => x.CorrespondenceId).GreaterThan(0);
        }
    }
}