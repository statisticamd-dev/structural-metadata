using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class RepresentedVariableValueDomain : AbstractDomain
    {
        public ValueDomainScope Scope { get; set; }
        public long RepresentedVariableId { get; set; }
        public RepresentedVariable RepresentedVariable { get; set; }
        public long ValueDomainId { get; set; }
        public ValueDomain ValueDomain { get; set; }
    }
}