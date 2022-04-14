using System;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure
{
    public class DataSet : AbstractIdentifiableArtefact
    {
        public DataSetType Type { get; set; }
        public ExchangeChannel ExchangeChannel { get; set; }
        public ExchangeDirection ExchangeDirection { get; set; }
        public DateTime? ReportingBegin { get; set; }
        public DateTime? ReportingEnd { get; set; }
        public long StatisticalProgramId { get; set; }
        public string Connection { get; set; }
        public string FilterExpression { get; set; }
        public long StructureId { get; set; }
        public DataStructure Structure { get; set; }
    }
}
