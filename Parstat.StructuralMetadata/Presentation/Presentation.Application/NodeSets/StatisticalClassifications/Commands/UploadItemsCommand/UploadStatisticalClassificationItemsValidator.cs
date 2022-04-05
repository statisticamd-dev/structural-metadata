using FluentValidation;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadItemsCommand
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