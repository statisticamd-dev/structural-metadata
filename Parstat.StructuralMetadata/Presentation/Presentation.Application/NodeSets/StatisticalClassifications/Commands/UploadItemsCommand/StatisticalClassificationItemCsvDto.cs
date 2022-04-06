using System.Collections.Generic;
using Presentation.Application.Common.Models.StructuralMetadata;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadItemsCommand
{
    public class StatisticalClassificationItemCsvDto
    {
        public string Code { get; set; }
        public MultilanguageStringDto label { get; set; }
        public long? LabelId { get; set; }
        public MultilanguageStringDto Desc { get; set; }
        public int? LevelNumber { get; set; }
        public List<StatisticalClassificationItemCsvDto> Children { get; set; }
    }
}
