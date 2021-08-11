using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;
using Presentation.Domain;

namespace Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim
{
    public abstract class AbstractConcept : AbstractIdentifiableArtefact, IConcept
    {
        public MultilanguageString Definition { get; set; }

        public MultilanguageString Link { get; set; }
    }
}