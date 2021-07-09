using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim
{
    public abstract class AbstractConcept : AbstractIdentifiableArtefact, IConcept
    {
        public string Definition { get; set; }

        public string Link { get; set; }
    }
}