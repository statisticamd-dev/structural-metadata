using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class Category : AbstractDomain
    {
        public string  Value { get; set; }

        public IEnumerable<Node> nodes { get; set; }
    }
}