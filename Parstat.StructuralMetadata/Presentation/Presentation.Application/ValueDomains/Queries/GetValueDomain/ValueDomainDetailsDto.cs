using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.ValueDomains.Queries.GetValueDomain
{
    public class ValueDomainDetailsDto : AbstractIdentifiableArtefactDto, IMapFrom<ValueDomain>
    {
        
        public ValueDomainType Type { get; set; }
        public ValueDomainScope Scope { get; set; }
        public string Expression { get; set; }
        public void Mapping(Profile profile)
        {
            //language passed as parameter on request
            //default to english
            string language = "en";
            profile.CreateMap<ValueDomain, ValueDomainDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ?s.VersionRationale.Text(language) : String.Empty)
                );
        }
    }
}