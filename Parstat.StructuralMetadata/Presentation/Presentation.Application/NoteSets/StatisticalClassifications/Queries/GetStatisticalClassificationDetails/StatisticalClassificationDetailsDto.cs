using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails
{
    public class StatisticalClassificationDetailsDto : IMapFrom<NodeSet>
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public MultilanguageStringDto Name { get; set; }
        public MultilanguageStringDto Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public MultilanguageStringDto VersionRationale { get; set; }
        public MultilanguageStringDto Link { get; set; }
        public List<LevelDetailsDto> Levels { get; set; }
        public List<StatisticalClassificationItemDto> StatisticalClassificationItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NodeSet, StatisticalClassificationDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Link))
                .ForMember(d => d.StatisticalClassificationItems, opt => opt.MapFrom(s => s.Nodes.Where(n => n.Parent == null)));
        }

    }
}