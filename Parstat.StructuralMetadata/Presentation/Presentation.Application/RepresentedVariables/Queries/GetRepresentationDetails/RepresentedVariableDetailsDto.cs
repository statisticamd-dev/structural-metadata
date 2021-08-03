using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class RepresentedVariableDetailsDto : IMapFrom<RepresentedVariable>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Definition { get; set; }
        public VariableMiniDto Variable { get; set; }
        public List<RepresentedVariableValueDomainDto> valueDomains { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepresentedVariable, RepresentedVariableDetailsDto>()
                .ForMember(d => d.Variable, opt => opt.MapFrom(s => s.Variable))
                .ForMember(d => d.valueDomains, opt => opt.MapFrom(s => s.valueDomains));
        }

    }
}