using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class RepresentedVariable : AbstractConcept
    {
        public Variable Variable { get; set; }
        public SubstantiveValueDomain SubstantiveValueDomain { get; set; }

        public SentinelValueDomain SentinelValueDomain {get; set;}
    }
}