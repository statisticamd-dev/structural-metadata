using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Correspondences.Queries.GetCorrespondence
{
    public class CorrespondenceDeteailsDto : AbstractBaseDto, IMapFrom<Correspondence>
    {
        public Relationship Relationship { get; set; }
        public NodesetMicroDto Source { get; set; }
        public NodesetMicroDto Target { get; set; }
        public IList<MappingDto> Mappings { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Correspondence, CorrespondenceDeteailsDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Source, opt => opt.MapFrom(s => s.Source))
                .ForMember(d => d.Target, opt => opt.MapFrom(s => s.Target))
                .ForMember(d => d.Relationship, opt => opt.MapFrom(s => s.Relationship))
                .ForMember(d => d.Mappings, opt => opt.MapFrom(s => s.Mappings));
        }

    }
}