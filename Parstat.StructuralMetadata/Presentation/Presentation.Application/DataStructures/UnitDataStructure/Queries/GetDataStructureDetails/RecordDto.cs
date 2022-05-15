using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Application.DataStructures.Common.GetDataStructureDetails;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructureDetails
{
    public class RecordDto : AbstractIdentifiableArtefactDto, IMapFrom<LogicalRecord>
    {
        public RecordTinyDto Parent { get; set; }
        public UnitTypeTinyDto UnitType { get; set; }
        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<LogicalRecord, RecordDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.Parent, opt => opt.MapFrom(s => s.Parent))
                .ForMember(d => d.UnitType, opt => opt.MapFrom(s => s.UnitType));
        }
    }
}