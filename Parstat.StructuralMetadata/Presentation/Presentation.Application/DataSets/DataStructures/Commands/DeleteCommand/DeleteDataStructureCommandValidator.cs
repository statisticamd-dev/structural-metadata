using FluentValidation;

namespace Presentation.Application.DataSets.DataStructures.Commands.DeleteCommand
{
    class DeleteDataStructureCommandValidator : AbstractValidator<DeleteDataStructureCommand>
    {
        public DeleteDataStructureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}