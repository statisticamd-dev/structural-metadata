using Presentation.Common.Domain.StructuralMetadata.Abstracts;

namespace Presentation.Domain.StructuralMetadata.Gsim.Concept
{
    public class Node : AbstractDomain
    {
        public NodeSet NodeSet { get; set; }

        public string Code { get; set; }

        public Level Level { get; set; }

        public Node Parent { get; set; }

        public Category Category { get; set; }

    }
}