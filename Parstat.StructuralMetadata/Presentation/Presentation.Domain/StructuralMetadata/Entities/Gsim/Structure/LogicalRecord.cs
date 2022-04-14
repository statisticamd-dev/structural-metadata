using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure
{
    public class LogicalRecord : AbstractIdentifiableArtefact
    {
        public long? ParentId { get; set; }
        public LogicalRecord Parent { get; set; }
        public long UnitTypeId { get; set; }
        public UnitType UnitType { get; set; }
        public long DataStructureId { get; set; }
        public DataStructure DataStructure { get; set; }
        public IList<Component> Components { get; set; }

        public LogicalRecord()
        {
            this.Components = new List<Component>();
        }
    }
}
