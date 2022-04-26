using FluentValidation;

namespace Presentation.Application.DataStructures.Commands.DeleteCommand
{
    class DeleteDataStructureCommandValidator : AbstractValidator<DeleteDataStructureCommand>
    {
        public DeleteDataStructureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}