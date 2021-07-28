using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Label : AbstractConcept
    {
         public IEnumerable<Node> Nodes { get; set; }

         public Label() {
            Nodes = new HashSet<Node>();
         }
    }
}