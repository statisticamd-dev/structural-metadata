using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Domain
{
    public class UnitType : AbstractIdentifiableArtefact, IUnitType
    {
        public string Definition { get; set; }
    }
}
