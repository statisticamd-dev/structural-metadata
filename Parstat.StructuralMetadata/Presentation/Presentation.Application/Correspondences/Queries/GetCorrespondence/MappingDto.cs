using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Correspondences.Queries.GetCorrespondence
{
    public class MappingDto : AbstractBaseDto, IMapFrom<Mapping>
    {
        public string SourceCode { get; set; }
        public string TargetCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mapping, MappingDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.SourceCode, opt => opt.MapFrom(s => s.Source.Code))
                .ForMember(d => d.TargetCode, opt => opt.MapFrom(s => s.Target.Code));
        } 
    }
}