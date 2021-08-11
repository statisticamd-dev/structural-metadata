using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class NodeDto : IMapFrom<Node>
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public MultilanguageStringDto Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Node, NodeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Label.Value));
        } 
    }
}