using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Label : AbstractDomain
    {
        public MultilanguageString Value { get; set; }
         public IEnumerable<Node> Nodes { get; set; }

         public Label() {
            Nodes = new HashSet<Node>();
         }
    }
}