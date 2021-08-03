using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class NodeSet : AbstractConcept
    {
        public NodeSet() {
            //SentinelValueDomains = new HashSet<ValueDomain>();
            //SubstantiveValueDomains = new HashSet<ValueDomain>();
        }
       // public IEnumerable<ValueDomain> SentinelValueDomains { get; set; }

        //public IEnumerable<ValueDomain>  SubstantiveValueDomains { get; set; }

        public NodeSetType NodeSetType { get; set; }
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Level> Levels { get; set; }

    }
}