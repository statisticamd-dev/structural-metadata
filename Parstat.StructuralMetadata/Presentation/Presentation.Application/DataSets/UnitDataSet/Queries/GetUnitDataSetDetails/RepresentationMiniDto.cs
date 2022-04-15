using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSetDetails
{
    public class RepresentationMiniDto : AbstractBaseDto, IMapFrom<RepresentedVariable>
    {
        public string Variable { get; set; }
        public SentinelValueDomainMiniDto SentinelValueDomain { get; set; }
        public SubstantiveValueDomainMiniDto SubstantiveValueDomain { get; set; }

         public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            
            profile.CreateMap<RepresentedVariable, RepresentationMiniDto>()
                .ForMember(d => d.Variable, opt => opt.MapFrom(s => s.Variable != null && s.Variable.Name != null ? s.Variable.Name.Text(language) : String.Empty))
                .ForMember(d => d.SubstantiveValueDomain, opt => opt.MapFrom(s => s.SubstantiveValueDomain != null ? s.SubstantiveValueDomain : null))
                .ForMember(d => d.SentinelValueDomain, opt => opt.MapFrom(s => s.SentinelValueDomain != null ? s.SentinelValueDomain : null)) ;
        }
    }
}
