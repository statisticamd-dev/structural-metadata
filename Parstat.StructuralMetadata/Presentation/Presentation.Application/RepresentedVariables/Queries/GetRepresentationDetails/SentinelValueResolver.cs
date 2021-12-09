using System.Collections.Generic;
using AutoMapper;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class SentinelValueResolver : IValueResolver<RepresentedVariable, RepresentedVariableDetailsDto, ValueDomainDto>
    {
        public ValueDomainDto Resolve(RepresentedVariable source, RepresentedVariableDetailsDto destination, ValueDomainDto destMember, ResolutionContext context)
        {
            context.Items["ValueDomainScope"] = "SENTINEL";
            return context.Mapper.Map<ValueDomainDto>(source.SentinelValueDomain);
           //throw new System.NotImplementedException();
        }
    }
}