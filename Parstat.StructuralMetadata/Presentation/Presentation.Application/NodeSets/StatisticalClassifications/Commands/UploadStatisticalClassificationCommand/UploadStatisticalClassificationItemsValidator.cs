using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand
{
    public class UploadStatisticalClassificationItemsValidator : AbstractValidator<UploadStatisticalClassificationItemsCommand>
    {
        public UploadStatisticalClassificationItemsValidator()
        {
            RuleFor(x => x.StatisticalClassificationId).NotEmpty().NotNull();
            RuleFor(x => x.RootItems).NotEmpty().NotNull();          
        }
    }
}