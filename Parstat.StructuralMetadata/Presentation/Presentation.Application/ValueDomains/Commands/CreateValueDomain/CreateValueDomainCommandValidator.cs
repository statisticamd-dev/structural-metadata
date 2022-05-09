using FluentValidation;
using Presentation.Application.ValueDomains.Commands.CreteValueDomain;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Application.ValueDomains.Commands.CreateValueDomain
{
    class CreateValueDomainCommandValidator : AbstractValidator<CreateValueDomainCommand>
    {
        public CreateValueDomainCommandValidator()
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Description).Length(5, 255);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Expression).NotEmpty().When(x => x.Type == ValueDomainType.DESCRIBED);
            //RuleFor(x => x.NodesetId).NotEmpty().When(x => x.Type == ValueDomainType.ENUMERATED); I think this is checked in the next one
            RuleFor(x => x.LevelId).NotEmpty().When(x => (x.Type == ValueDomainType.ENUMERATED && x.NodesetId == null));
            RuleFor(x => x.DataType).IsInEnum();
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
