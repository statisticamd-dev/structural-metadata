using FluentValidation;

namespace Presentation.Application.NodeSets.CodeLists.Commands.AddCodeItemCommand
{
    public class AddCodeItemCommandValidator : AbstractValidator<AddCodeItemCommand>
    {
        public AddCodeItemCommandValidator() 
        {
            RuleFor(x => x.NodeSetId).NotEmpty();
            RuleFor(x => x.Code).Length(1, 50).NotEmpty();
            RuleFor(x => x.Value).NotNull();
        }
    }
}