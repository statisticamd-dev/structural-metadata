using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class RepresentedVariable : AbstractConcept
    {
        public RepresentedVariable() 
        {
            ValueDomains = new List<RepresentedVariableValueDomain>();
        }
        public long VariableId { get; set; }
        public Variable Variable { get; set; }
        public IList<RepresentedVariableValueDomain> ValueDomains { get; set; }
    }
}