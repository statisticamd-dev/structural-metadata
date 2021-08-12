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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Definition { get; set; }
        public VariableMiniDto Variable { get; set; }
        public List<RepresentedVariableValueDomainDto> valueDomains { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<RepresentedVariable, RepresentedVariableDetailsDto>()
                .ForMember(d => d.Variable, opt => opt.MapFrom(s => s.Variable))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition.Text(language)))
                .ForMember(d => d.valueDomains, opt => opt.MapFrom(s => s.valueDomains));
        }

    }
}