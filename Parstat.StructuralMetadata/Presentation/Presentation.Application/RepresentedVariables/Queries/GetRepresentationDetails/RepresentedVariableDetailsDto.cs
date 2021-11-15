using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class RepresentedVariableDetailsDto : AbstractConceptDto, IMapFrom<RepresentedVariable>
    {
        public VariableMiniDto Variable { get; set; }
        //public ValueDomainDto SentinelValueDomain { get; set; }
        public ValueDomainDto SubstantiveValueDomain { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<RepresentedVariable, RepresentedVariableDetailsDto>()
                .ForMember(d => d.Variable, opt => opt.MapFrom(s => s.Variable))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition != null ? s.Definition.Text(language) : null))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Link != null ? s.Link.Text(language) : null))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : null))
                .ForMember(d => d.SubstantiveValueDomain, opt => opt.MapFrom(s => s.SubstantiveValueDomain));
                //.ForMember(d => d.SentinelValueDomain, opt => opt.MapFrom(s => s.SentinelValueDomain != null ? s.SentinelValueDomain : null));
        }

    }
}