using FluentValidation;
using Presentation.Application.NoteSets.Commands;
using Presentation.Application.Variables.Commands.DeleteVariable;

namespace Presentation.Application.NoteSets.Commands.DeleteCodeItem
{
    public class DeleteCodeItemCommandValidator : AbstractValidator<DeleteCodeItemCommand>
    {
        public DeleteCodeItemCommandValidator()
        {
            RuleFor(x => x.NodeSetId).NotNull();
            RuleFor(x => x.Code).NotNull().NotEmpty();
        }
    }
}