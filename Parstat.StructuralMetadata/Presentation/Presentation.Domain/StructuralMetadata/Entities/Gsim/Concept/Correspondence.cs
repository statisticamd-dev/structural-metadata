using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Correspondence : AbstractDomain
    {
        public Correspondence() 
        {
            Mappings = new List<Mapping>();
        }        
        public long SourceId { get; set; }
        public NodeSet Source { get; set; }
        public long TargetId { get; set; }
        public NodeSet Target { get; set; }
        public Relationship Relationship { get; set; }
        public IList<Mapping> Mappings { get; set; }
    }
}