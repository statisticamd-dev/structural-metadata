using FluentValidation;

namespace Presentation.Application.NoteSets.CodeLists.Commands.UpdateCommand
{
    public class UpdateCodeListCommandValidator : AbstractValidator<UpdateCodeListCommand>
    {
        public UpdateCodeListCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3);
            RuleFor(x => x.Description).MinimumLength(3);
            RuleFor(x => x.Version).MinimumLength(1);
            RuleFor(x => x.VersionRationale).MinimumLength(1);
            
        }
    }
}