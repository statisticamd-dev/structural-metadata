using FluentValidation;

namespace Presentation.Application.NoteSets.CodeLists.Commands.AddCodeItemCommand
{
    public class AddCodeItemCommandValidator : AbstractValidator<AddCodeItemCommand>
    {
        public AddCodeItemCommandValidator() 
        {
            RuleFor(x => x.NodeSetId).NotNull();
            RuleFor(x => x.Code).Length(1, 50).NotEmpty().NotNull();
            RuleFor(x => x.LabelId).NotNull();
        }
    }
}