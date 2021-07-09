using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Common.Domain.StructuralMetadata.Interfaces.Gsim.Concept;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class SubstantiveValueDomain : ValueDomain 
    {
        public IEnumerable<RepresentedVariable> RepresentedVariables { get; set; }

        //Level property
    }
}