using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class RepresentedVariableDto : IMapFrom<RepresentedVariable>
    {
        public long Id { get; set; }
        public string LocalId { get; set; }
        public MultilanguageStringDto Name { get; set; }
        public MultilanguageStringDto Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepresentedVariable, RepresentedVariableDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.LocalId, opt => opt.MapFrom(s => s.LocalId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}