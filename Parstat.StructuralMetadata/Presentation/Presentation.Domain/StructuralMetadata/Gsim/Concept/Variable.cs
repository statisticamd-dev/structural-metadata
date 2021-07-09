using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class Variable : AbstractConcept
    {
        public UnitType Measures { get; set; }

        public virtual IEnumerable<RepresentedVariable> Representations { get; set; }
    }
}