using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class ValueDomain : AbstractIdentifiableArtefact
    {
        public ValueDomain() {
            //RepresentedVariables = new HashSet<RepresentedVariable>();
        }

      
        public ValueDomainType Type { get; set; }
        public ValueDomainScope Scope { get; set; }
        public string Expression { get; set; }
        public long NodeSetId { get; set; }
        public NodeSet NodeSet { get; set; }
        public int LevelNumber { get; set; }
        //public IEnumerable<RepresentedVariable> RepresentedVariables { get; set; }


    }
}