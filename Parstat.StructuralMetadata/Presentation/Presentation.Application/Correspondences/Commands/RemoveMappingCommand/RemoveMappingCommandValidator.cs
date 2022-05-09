using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.RemoveMappingCommand
{
    public class RemoveMappingCommandValidator : AbstractValidator<RemoveMappingCommand>
    {
        public RemoveMappingCommandValidator()
        {
            RuleFor(x => x.CorrespondenceId).NotEmpty();
            RuleFor(x => x.MappingId).NotEmpty();
        }
    }
}