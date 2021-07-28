using Presentation.Common.Domain;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Variable : AbstractConcept
    {
        public Variable() {
            Representations = new HashSet<RepresentedVariable>();
        }

        public long MeasuresId { get; set; }
        public UnitType Measures { get; set; }
        public IEnumerable<RepresentedVariable> Representations { get; set; }
    }
}