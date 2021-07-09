using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class SentinelValueDomain : ValueDomain
    {
        public IEnumerable<RepresentedVariable> RepresentedVariables { get; set; }
    }
}