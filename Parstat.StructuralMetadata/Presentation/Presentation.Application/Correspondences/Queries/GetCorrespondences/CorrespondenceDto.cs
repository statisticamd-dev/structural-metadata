using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Correspondences.Queries.GetCorrespondences
{
    public class CorrespondenceDto : AbstractBaseDto, IMapFrom<Correspondence>
    {
        public Relationship Relationship { get; set; }
        public NodeSetMiniDto Source { get; set; }
        public NodeSetMiniDto Target { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Correspondence, CorrespondenceDto>()
                .ForMember(d => d.Relationship, opt => opt.MapFrom(s => s.Relationship))
                .ForMember(d => d.Source, opt => opt.MapFrom(s => s.Source))
                .ForMember(d => d.Target, opt => opt.MapFrom(s => s.Target));
        }
    }
}