using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Category : AbstractConcept
    {
        public Category() {
            Nodes = new HashSet<Node>();
        }
        public IEnumerable<Node> Nodes { get; set; }
    }
}