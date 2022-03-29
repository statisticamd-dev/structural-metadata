using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.RemoveMappingCommand
{
    public class RemoveMappingCommandValidator : AbstractValidator<RemoveMappingCommand>
    {
        public RemoveMappingCommandValidator()
        {
            RuleFor(x => x.CorrespondenceId).GreaterThan(0);
            RuleFor(x => x.MappingId).GreaterThan(0);
        }
    }
}