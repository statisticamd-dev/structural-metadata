using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.UnitTypes.Queries.GetUnitTypes
{
    public class UnitTypeDto : AbstractBaseDto, IMapFrom<UnitType>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Descriptin { get; set; }
         public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<UnitType, UnitTypeDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.Descriptin, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null)
               );
        } 
    }
}