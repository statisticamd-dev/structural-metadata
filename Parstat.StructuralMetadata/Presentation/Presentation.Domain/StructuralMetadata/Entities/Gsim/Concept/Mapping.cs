using Presentation.Common.Domain.StructuralMetadata.Abstracts;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Mapping : AbstractDomain
    {
        public long CorrespondenceId { get; set; }
        public Correspondence Correspondence { get; set; }
        public long TargetId { get; set; }
        public Node Target { get; set; }
        public long SourceId { get; set; }
        public Node Source { get; set; }
    }
}