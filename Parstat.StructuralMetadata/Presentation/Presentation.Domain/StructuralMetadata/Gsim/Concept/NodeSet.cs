using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class NodeSet : AbstractConcept
    {
        public IEnumerable<SentinelValueDomain> sentinelValueDomains { get; set; }

        public IEnumerable<SubstantiveValueDomain>  substantiveValueDomains { get; set; }

        public NodeSetType NodeSetType { get; set; }

        public IEnumerable<SentinelValueDomain> Sentinels { get; set; }

        public IEnumerable<SubstantiveValueDomain> Substantives { get; set; }


    }
}