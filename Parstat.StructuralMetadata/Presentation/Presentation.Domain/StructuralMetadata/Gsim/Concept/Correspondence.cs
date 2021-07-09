using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class Correspondence : AbstractDomain
    {
        public NodeSet Source { get; set; }

        public NodeSet Target { get; set; }

        public Relationship Relationship { get; set; }
    }
}