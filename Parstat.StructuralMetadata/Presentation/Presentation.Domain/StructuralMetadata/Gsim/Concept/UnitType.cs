using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class UnitType : AbstractIdentifiableArtefact, IUnitType
    {
        public string Definition { get; set; }
    }
}
