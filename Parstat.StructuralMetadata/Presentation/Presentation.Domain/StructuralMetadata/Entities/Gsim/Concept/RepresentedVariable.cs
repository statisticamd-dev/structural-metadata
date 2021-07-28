using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class RepresentedVariable : AbstractConcept
    {
        public long VariableId { get; set; }
        public long SubstantiveValueDomainId { get; set; }
        public long SentinelValueDomainId { get; set; }
        public Variable Variable { get; set; }
        public ValueDomain SubstantiveValueDomain { get; set; }
        public ValueDomain SentinelValueDomain {get; set;}
    }
}