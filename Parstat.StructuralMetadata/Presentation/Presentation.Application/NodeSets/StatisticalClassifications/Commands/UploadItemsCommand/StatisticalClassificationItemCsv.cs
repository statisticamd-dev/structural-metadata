using System;
using Presentation.Application.Common.Models.StructuralMetadata.Interfaces;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadItemsCommand
{
    public class StatisticalClassificationItemCsv : IRecordCsv
    {
        
        public string Code { get; set; }
        public string Label_En { get; set; }
        public string Label_Ru { get; set; }
        public string Label_Ro { get; set; }
        public int LevelNumber { get; set; }
        public string ParentCode { get; set; }
        public long LabelId { get; set; }
    }
}
