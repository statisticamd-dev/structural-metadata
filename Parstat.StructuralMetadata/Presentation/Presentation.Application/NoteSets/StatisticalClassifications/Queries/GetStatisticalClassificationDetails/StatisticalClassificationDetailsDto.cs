using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails
{
    public class StatisticalClassificationDetailsDto : AbstractConceptDto, IMapFrom<NodeSet>
    {
        public List<LevelDetailsDto> Levels { get; set; }
        public List<StatisticalClassificationItemDto> StatisticalClassificationItems { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, StatisticalClassificationDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale.Text(language)))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Link.Text(language)))
                .ForMember(d => d.StatisticalClassificationItems, opt => opt.MapFrom(s => s.Nodes.Where(n => n.Parent == null)));
        }

    }
}