using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class UnitType : AbstractConcept
    {
        public UnitType() {
            Variables = new HashSet<Variable>();
        }
        public IEnumerable<Variable> Variables { get; set; }
    }
}
