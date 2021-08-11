using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class RepresentedVariableDetailsDto : IMapFrom<RepresentedVariable>
    {
        public string LocalId { get; set; }
        public MultilanguageStringDto Name { get; set; }
        public MultilanguageStringDto Description { get; set; }
        public string Version { get; set; }
        public MultilanguageStringDto Definition { get; set; }
        public VariableMiniDto Variable { get; set; }
        public List<RepresentedVariableValueDomainDto> valueDomains { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepresentedVariable, RepresentedVariableDetailsDto>()
                .ForMember(d => d.Variable, opt => opt.MapFrom(s => s.Variable))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition))
                .ForMember(d => d.valueDomains, opt => opt.MapFrom(s => s.valueDomains));
        }

    }
}