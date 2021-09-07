using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Correspondence : AbstractDomain
    {
        public long SourceId { get; set; }
        public NodeSet Source { get; set; }
        public long TargetId { get; set; }
        public NodeSet Target { get; set; }
        public Relationship Relationship { get; set; }
        public IEnumerable<Mapping> Mappings { get; set; }
    }
}