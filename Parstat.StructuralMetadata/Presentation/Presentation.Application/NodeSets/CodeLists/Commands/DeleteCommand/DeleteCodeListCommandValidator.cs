using System;
using FluentValidation;

namespace Presentation.Application.NodeSets.CodeLists.Commands.DeleteCommand
{
    public class DeleteCodeListCommandValidator : AbstractValidator<DeleteCodeListCommand>
    {
        public DeleteCodeListCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
