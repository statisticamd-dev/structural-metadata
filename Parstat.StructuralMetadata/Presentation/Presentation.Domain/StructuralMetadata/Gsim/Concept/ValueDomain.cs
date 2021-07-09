using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class ValueDomain : AbstractIdentifiableArtefact
    {
        public ValueDomainType ValueDomainType { get; set; }

        public string Expression { get; set; }

        public NodeSet NodeSet { get; set; }

    }
}