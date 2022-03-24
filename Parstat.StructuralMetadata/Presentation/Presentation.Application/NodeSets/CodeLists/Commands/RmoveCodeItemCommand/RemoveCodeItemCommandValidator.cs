using FluentValidation;

namespace Presentation.Application.NodeSets.CodeList.Commands.RemoveCodeItemCommand
{
    public class RemoveCodeItemCommandValidator : AbstractValidator<RemoveCodeItemCommand>
    {
        public RemoveCodeItemCommandValidator()
        {
            RuleFor(x => x.NodeSetId).NotNull();
            RuleFor(x => x.Code).NotNull().NotEmpty();
        }
    }
}