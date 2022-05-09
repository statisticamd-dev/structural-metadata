using FluentValidation;
namespace Presentation.Application.Correspondences.Commands.AddMappingCommand
{
    public class UploadMappingValidator : AbstractValidator<UploadMappingCommand.UploadMappingCommand>
    {
        public UploadMappingValidator()
        {
            RuleFor(x => x.MappingCsv).NotEmpty();
        }
    }
}