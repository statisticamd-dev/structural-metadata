using System;
using System.Collections.Generic;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadItemsCommand
{
    public class StatisticalClassificationItemCsvDto
    {
        public string Code { get; set; }
        public MultilanguageStringDto label { get; set; }
        public long? LabelId { get; set; }
        public MultilanguageStringDto Description { get; set; }
        public int? LevelNumber { get; set; }
        public List<StatisticalClassificationItemCsvDto> Children { get; set; }
    }
}
