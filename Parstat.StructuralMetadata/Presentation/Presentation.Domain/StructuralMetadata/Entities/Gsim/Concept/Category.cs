using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Category : AbstractConcept
    {
        public Category() {
            Nodes = new List<Node>();
        }
        public IList<Node> Nodes { get; set; }
    }
}