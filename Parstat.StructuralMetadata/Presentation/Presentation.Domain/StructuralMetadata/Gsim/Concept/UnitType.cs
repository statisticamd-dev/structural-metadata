using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class UnitType : AbstractConcept
    {
        public IEnumerable<Variable> Variables { get; set; }
    }
}
