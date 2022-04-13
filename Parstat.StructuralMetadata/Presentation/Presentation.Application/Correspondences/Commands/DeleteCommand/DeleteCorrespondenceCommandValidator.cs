using System;
using FluentValidation;

namespace Presentation.Application.Correspondences.Commands.DeleteCommand
{
    public class DeleteCorrespondenceCommandValidator : AbstractValidator<DeleteCorrespondenceCommand>
    {
        public DeleteCorrespondenceCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
        
    }
}
