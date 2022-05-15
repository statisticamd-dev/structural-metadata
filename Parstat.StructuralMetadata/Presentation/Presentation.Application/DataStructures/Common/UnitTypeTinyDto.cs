using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.DataStructures.Common.GetDataStructureDetails
{
    public class UnitTypeTinyDto : AbstractBaseDto, IMapFrom<UnitType>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<UnitType, UnitTypeTinyDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty));
        }
    }
}