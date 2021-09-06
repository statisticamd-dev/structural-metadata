using AutoMapper;
using System;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit
{
    public class MeasurementUnitDetailDto : AbstractIdentifiableArtefactDto, IMapFrom<MeasurementUnit>
    {
        public bool IsStandard { get; set; }
        public string Abbreviation { get; set; }
        public string ConvertionRule { get; set; }
        public MeasurementTypeMiniDto MeasurementType { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<MeasurementUnit, MeasurementUnitDetailDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Text(language)))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale.Text(language)))
                .ForMember(d => d.MeasurementType, opt => opt.MapFrom(s => s.MeasurementType));
        }
    }
}