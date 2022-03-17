using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class Level : AbstractIdentifiableArtefact
    {
        public Level() {
            Nodes = new List<Node>();
        }
        public int LevelNumber { get; set; }
        public long NodeSetId { get; set; }
        public NodeSet NodeSet { get; set; }
        public IList<Node> Nodes { get; set; }

        public long LevelId { get; set; }

        //public SubstantiveValueDomain SubstantiveValueDomain { get; set; }
    }
}