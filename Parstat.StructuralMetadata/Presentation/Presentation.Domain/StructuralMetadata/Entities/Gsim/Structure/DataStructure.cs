using System;
using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure
{
    public class DataStructure : AbstractIdentifiableArtefact
    {
        public DatasetType Type { get; set; }
        public string Group { get; set; }
        public IList<LogicalRecord> LogicalRecords { get; set; }
        public IList<Component> Components { get; set; }
        public IList<DataSet> DataSets { get; set; }

        public DataStructure() {
            this.LogicalRecords = new List<LogicalRecord>();
            this.Components = new List<Component>();
            this.DataSets = new List<DataSet>();
        }
    }
}
