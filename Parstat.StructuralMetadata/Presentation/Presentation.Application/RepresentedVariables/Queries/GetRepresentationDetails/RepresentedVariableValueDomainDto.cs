using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class RepresentedVariableValueDomainDto : AbstractBaseDto, IMapFrom<RepresentedVariableValueDomain>
    {
        public ValueDomainScope Scope { get; set; }
        public ValueDomainDto ValueDoman { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepresentedVariableValueDomain, RepresentedVariableValueDomainDto>()
                .ForMember(d => d.Scope, opt => opt.MapFrom(s => s.Scope))
                .ForMember(d => d.ValueDoman, opt => opt.MapFrom(s => s.ValueDomain));
        }
    }
}