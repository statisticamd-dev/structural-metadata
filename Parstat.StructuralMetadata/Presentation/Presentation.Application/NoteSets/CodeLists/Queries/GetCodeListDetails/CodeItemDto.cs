using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NoteSets.CodeLists.Queries.GetCodeListDetails
{
    public class CodeItemDto :IMapFrom<Node>
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Node, CodeItemDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Label.Name));
        } 
    }
}