using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class UnitType : AbstractConcept
    {
        public UnitType() {
            Variables = new List<Variable>();
            Records = new List<LogicalRecord>();
        }
        public IList<Variable> Variables { get; set; }
        public IList<LogicalRecord> Records { get; set; }
    }
}
