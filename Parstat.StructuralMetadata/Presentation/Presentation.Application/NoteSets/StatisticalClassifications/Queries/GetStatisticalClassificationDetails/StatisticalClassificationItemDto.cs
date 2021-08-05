using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.StatisticalClassifications.Queries.GetStatisticalClassificationDetails
{
    public class StatisticalClassificationItemDto : IMapFrom<Node>
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public int LevelNumber { get; set; }
        public List<StatisticalClassificationItemDto> Children { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Node, StatisticalClassificationItemDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Label.Name))
                .ForMember(d => d.LevelNumber, opt => opt.MapFrom(s => s.Level.LevelNumber))
                .ForMember(d => d.Children, opt => opt.MapFrom(s => s.Children));
        }
    }
}