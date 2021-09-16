using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit
{
    public class MeasurementTypeMiniDto : AbstractBaseDto, IMapFrom<MeasurementType>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<MeasurementType, MeasurementTypeMiniDto>()
                .ForMember(d => d.LocalId, opt => opt.MapFrom(s => s.LocalId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null)
                );
        }
    }
}