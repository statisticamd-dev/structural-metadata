using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails
{
    public class StatisticalClassificationDetailsDto : IMapFrom<NodeSet>
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public string Link { get; set; }
        public List<LevelDetailsDto> Levels { get; set; }
        public List<StatisticalClassificationItemDto> StatisticalClassificationItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NodeSet, StatisticalClassificationDetailsDto>()
                .ForMember(d => d.StatisticalClassificationItems, opt => opt.MapFrom(s => s.Nodes.Where(n => n.Parent == null)));
        }

    }
}