using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.UnitTypes.Queries.GetUnitType
{
    public class UnitTypeDetailsDto : AbstractConceptDto, IMapFrom<UnitType>
    {
        public void Mapping(Profile profile)
        {
            //language passed as parameter on request
            //default to english
            string language = "en";
            profile.CreateMap<UnitType, UnitTypeDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition.Text(language)))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale.Text(language))
                );
        }
    }
}