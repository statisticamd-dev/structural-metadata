using Presentation.Application.Common.Models.StructuralMetadata.Interfaces;

namespace Presentation.Application.Common.Models.StructuralMetadata.Abstracts
{
    public abstract class AbstractConceptDto : AbstractIdentifiableArtefactDto, IConceptDto
    {
        public string Definition { get; set; }
        public string Link { get; set; }
    }
}