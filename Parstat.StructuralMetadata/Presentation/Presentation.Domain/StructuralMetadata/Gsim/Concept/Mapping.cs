using Presentation.Common.Domain.StructuralMetadata.Abstracts;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class Mapping : AbstractDomain
    {
        public Correspondence Correspondence { get; set; }

        public Node Target { get; set; }
        
        public Node Source { get; set; }
    }
}