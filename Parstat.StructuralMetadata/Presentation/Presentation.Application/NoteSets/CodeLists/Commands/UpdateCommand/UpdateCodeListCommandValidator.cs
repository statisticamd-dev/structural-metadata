using FluentValidation;

namespace Presentation.Application.NoteSets.CodeLists.Commands.UpdateCommand
{
    public class UpdateCodeListCommandValidator : AbstractValidator<UpdateCodeListCommand>
    {
        public UpdateCodeListCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.Description).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(x => x.Version).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.VersionRationale).MinimumLength(1).NotEmpty().NotNull();
            RuleFor(x => x.LocaLId).MinimumLength(1).NotEmpty().NotNull();
            
        }
    }
}