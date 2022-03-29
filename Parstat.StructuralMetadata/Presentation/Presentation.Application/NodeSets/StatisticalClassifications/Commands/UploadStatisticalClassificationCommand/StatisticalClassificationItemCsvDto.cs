using System;
using System.Collections.Generic;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand
{
    public class StatisticalClassificationItemCsvDto
    {
        public string Code { get; set; }
        public string ValueEn { get; set; }
        public string ValueRo { get; set; }
        public string ValueRu { get; set; }
        public long? LabelId { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionRo { get; set; }
        public int? LevelNumber { get; set; }
        public List<StatisticalClassificationItemCsvDto> Children { get; set; }
    }
}
