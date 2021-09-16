using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Node : AbstractDomain
    {
        public Node() 
        {
            Children = new HashSet<Node>();
        }
        public long NodeSetId { get; set; }
        public long? LevelId { get; set; }
        public long? ParentId { get; set; }
        public long? CategoryId { get; set; }
        public NodeSet NodeSet { get; set; }
        public string Code { get; set; }
        public Level Level { get; set; }
        public Node Parent { get; set; }
        public Category Category { get; set; }
        public AggregationType AggregationType { get; set; }
        public long LabelId { get; set; }
        public Label Label { get; set; }
        public IEnumerable<Node> Children { get; set; }

    }
}