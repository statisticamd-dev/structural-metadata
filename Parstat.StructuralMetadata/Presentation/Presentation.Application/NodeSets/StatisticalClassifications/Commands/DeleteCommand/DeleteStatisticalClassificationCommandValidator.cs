using System;
using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.DeleteCommand
{
    public class DeleteStatisticalClassificationCommandValidator : AbstractValidator<DeleteStatisticalClassificationCommand>
    {
        public DeleteStatisticalClassificationCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
